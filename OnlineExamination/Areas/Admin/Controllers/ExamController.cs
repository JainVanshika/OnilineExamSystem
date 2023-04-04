using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineExam.DataAccess.Repository.IRepository;
using OnlineExam.Models;
using OnlineExam.Models.ViewModel;

namespace OnlineExamination.Areas.Admin.Controllers
{
    public class ExamController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ExamController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<ExamDetails> objExamList = _unitOfWork.ExamDetail.GetAll(includeProperties:"Category,Subject");
            return View(objExamList);
        }
        public IActionResult Upsert(int? id)
        {
            ExamVM examVM = new()
            {
                ExamDetails= new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem{
                    Text=u.CategoryName,
                    Value=u.Id.ToString(),
                }),
                SubjectList=_unitOfWork.Subject.GetAll().Select(u=>new SelectListItem
                {
                    Text=u.SubjectName,
                    Value=u.Id.ToString(),
                }),
            };
            if(id==null||id==0)
            {
                return View(examVM);
            }
            else
            {
                examVM.ExamDetails=_unitOfWork.ExamDetail.GetFirstOrDefault(u=>u.ExamId==id);
                return View(examVM);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ExamVM obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.ExamDetails.ExamId == 0)
                {
                    _unitOfWork.ExamDetail.Add(obj.ExamDetails);
                    TempData["success"] = "Exam created successfully";
                }
                else
                {
                    _unitOfWork.ExamDetail.Update(obj.ExamDetails);
                    TempData["success"] = "Exam updated successfully";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var objDelete = _unitOfWork.ExamDetail.GetFirstOrDefault(u => u.ExamId == id);
            if(objDelete == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.ExamDetail.Remove(objDelete);
                _unitOfWork.Save();
                TempData["success"] = "Exam deleted successfully";
                return RedirectToAction("Index");
            }
        }
    }
}
