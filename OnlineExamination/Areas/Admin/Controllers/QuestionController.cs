using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineExam.DataAccess.Repository.IRepository;
using OnlineExam.Models;
using OnlineExam.Models.ViewModel;

namespace OnlineExamination.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuestionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuestionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            IEnumerable<Questions> objAllQues = _unitOfWork.questions.GetAll(includeProperties:"ExamDetails");
            return View(objAllQues);
        }
        public IActionResult ExamQuestion(int? id)
        {
            IEnumerable<Questions> ExamQues = _unitOfWork.questions.GetAll(u => u.ExamsId == id, includeProperties: "ExamDetails");
            return View(ExamQues);
        }
        public IActionResult AddQuestion()
        {
            QuestionVM questionVM = new()
            {
                Questions = new(),
                ExamList = _unitOfWork.ExamDetail.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.ExamId.ToString(),
                }),
            };
            //questionVM.Questions = _unitOfWork.questions.GetFirstOrDefault(u => u.Id == id);
            return View(questionVM);
            //return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddQuestion(QuestionVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.questions.Add(obj.Questions);
                _unitOfWork.Save();
                TempData["success"] = "Question Added successfully";

                //return RedirectToAction("Index");
                return RedirectToAction("ExamQuestion", new { id = obj.Questions.ExamsId });
            }
            return View(obj);
        }
        public IActionResult Detail(int? id)
        {
            if(id==0||id==null)
            {
                return NotFound();
            }
            var detailDB=_unitOfWork.questions.GetFirstOrDefault(x => x.Id==id);
            if(detailDB==null)
            {
                return NotFound();
            }
            else
            {
                return View(detailDB);
            }
        }
        public IActionResult Edit(int? id)
        {
            QuestionVM questionVM = new()
            {
                Questions = new(),
                ExamList = _unitOfWork.ExamDetail.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.ExamId.ToString(),
                }),
            };
            questionVM.Questions = _unitOfWork.questions.GetFirstOrDefault(u => u.Id == id);
            return View(questionVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(QuestionVM obj)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.questions.Update(obj.Questions);
                _unitOfWork.Save();
                TempData["success"] = "Question updated successfully";
                return RedirectToAction("ExamQuestion",new {id=obj.Questions.ExamsId});

            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var objDelete = _unitOfWork.questions.GetFirstOrDefault(u => u.Id == id);
            if (objDelete == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.questions.Remove(objDelete);
                _unitOfWork.Save();
                TempData["success"] = "Question deleted successfully";
                //return RedirectToAction("Index");
                return RedirectToAction("ExamQuestion", new { id = objDelete.ExamsId });
            }
        }
    }
}
