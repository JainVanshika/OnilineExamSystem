using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using OnlineExam.DataAccess.Repository.IRepository;
using OnlineExam.Models;
using System.ComponentModel;

namespace OnlineExamination.Areas.Admin.Controllers
{
    //[Area("Admin")]
    public class SubjectController : Controller
    {
        //dependency injection
        private readonly IUnitOfWork _unitOfWork;
        public SubjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //category list
        public IActionResult Index()
        {
            IEnumerable<Subject> objSubjectList = _unitOfWork.Subject.GetAll();
            return View(objSubjectList);
        }
        //get category
        public IActionResult Create()
        {
            return View();
        }
        //post category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Subject obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Subject.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Subject created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SubjectDBedit = _unitOfWork.Subject.GetFirstOrDefault(u => u.Id == id);
            if (SubjectDBedit == null)
            {
                return NotFound();
            }
            return View(SubjectDBedit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Subject subject)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Subject.Update(subject);
                _unitOfWork.Save();
                TempData["success"] = "Subject edited successfully";
                return RedirectToAction("Index");
            }
            return View(subject);
        }
        //delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SubjectDBdelete = _unitOfWork.Subject.GetFirstOrDefault(u => u.Id == id);
            if (SubjectDBdelete == null)
            {
                return NotFound();
            }
            return View(SubjectDBdelete);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Subject.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Subject.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Subject deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
