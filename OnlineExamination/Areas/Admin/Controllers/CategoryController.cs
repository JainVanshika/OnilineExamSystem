using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using OnlineExam.DataAccess.Repository.IRepository;
using OnlineExam.Models;
using System.ComponentModel;

namespace OnlineExamination.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        //dependency injection
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //subject list
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll();
            return View(objCategoryList);
        }
        //get subject
        public IActionResult Create()
        {
            return View();
        }
        //post subject
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
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
            var categoryDBedit = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (categoryDBedit == null)
            {
                return NotFound();
            }
            return View(categoryDBedit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "category edited successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        //delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryDBdelete = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (categoryDBdelete == null)
            {
                return NotFound();
            }
            return View(categoryDBdelete);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
