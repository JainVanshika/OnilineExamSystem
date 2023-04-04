using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic;
using OnlineExam.DataAccess.Repository.IRepository;
using OnlineExam.Models;
using OnlineExam.Models.ViewModel;
//using System.Web.Mvc;

namespace OnlineExamination.Areas.Admin.Controllers
{
    //[Area("Admin")]
    public class SubjectController : Controller
    {
        //dependency injection
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostEnvironment _hostEnvironment;
        public SubjectController(IUnitOfWork unitOfWork, IHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        //subject list
        public IActionResult Index()
        {
            IEnumerable<Subject> objSubjectList = _unitOfWork.Subject.GetAll(includeProperties:"Category");
            return View(objSubjectList);
        }
        //upsert category
        public IActionResult Upsert(int? id)
        {
            SubjectVM subjectVM = new()
            {
                Subject =new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.Id.ToString(),
                }),
            };
            if(id==null||id==0)
            {
                return View(subjectVM);
            }
            else
            {
                subjectVM.Subject=_unitOfWork.Subject.GetFirstOrDefault(u => u.Id==id);
                return View(subjectVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(SubjectVM obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Subject.Id == 0)
                {
                    _unitOfWork.Subject.Add(obj.Subject);
                    TempData["success"] = "Subject created successfully.";
                }
                else
                {
                    _unitOfWork.Subject.Update(obj.Subject);
                    TempData["success"] = "Subject updated successfully.";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        
        //delete
        public IActionResult Delete(int? id)
        {
            if (id==null||id == 0)
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
