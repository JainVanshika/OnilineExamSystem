using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineExam.DataAccess.Repository.IRepository;
using OnlineExam.Models;
using OnlineExam.Models.ViewModel;
using System.Diagnostics;
using System.Security.Claims;

namespace OnlineExamination.Areas.Student.Controllers
{
    [Area("Student")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public QuesResultVM QuesResultVM { get; set; }
        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;   
        }

        public IActionResult Index()
        {
           // var itemId = Request.Query["id"];
            IEnumerable<Category> categoryList=_unitOfWork.Category.GetAll();
            return View(categoryList);
        }
        public IActionResult Subject(int? id)
        {
            IEnumerable<Subject> subjectList = _unitOfWork.Subject.GetAll(x=>x.CategoryId==id);
            return View(subjectList);
        }
        public IActionResult Exam(int? id)
        {
            IEnumerable<ExamDetails> examlist = _unitOfWork.ExamDetail.GetAll(x=>x.SubjectId==id);
            return View(examlist);
        }
        public IActionResult QuesAns(int? id)
        {
            /*var claimsIdentiy = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentiy.FindFirst(ClaimTypes.NameIdentifier);*/

            IEnumerable<Questions> quesList = _unitOfWork.questions.GetAll(x => x.ExamsId == id);
            //Result result = _unitOfWork.Result.GetFirstOrDefault(x=>x.ApplicationId==claim.Value);
            //ExamDetails examDetails = _unitOfWork.ExamDetail.GetFirstOrDefault(x => x.ExamId == id);

            QuesResultVM quesResultVM = new QuesResultVM()
            {
                Questions = quesList,
               // ExamDetails = examDetails,
                // Result=result,
            };
            return View(quesResultVM);
        }
        /*[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult QuesAns(QuesResultVM model,Result obj)
        {
            *//*var claimsIdentiy = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentiy.FindFirst(ClaimTypes.NameIdentifier);
            model.ApplicationUser = _unitOfWork.ApplicationUsers.GetFirstOrDefault(u => u.Id == claim.Value);
            model.ExamDetails = _unitOfWork.ExamDetail.GetFirstOrDefault(u => u.ExamId == id);
            model.Questions=_unitOfWork.questions.GetAll(x=>x.ExamsId==id);*//*
            //model.Result=_unitOfWork.Result.GetAll(x=>x.ApplicationId==claim.Value);
            //QuesResultVM.ListCart = _unitOfWork.shoppingCart.GetAll(u => u.ApplicationUserId == claim.Value, includeProperties: "Product");
            if (TryValidateModel(model))
            {
                if (ModelState.IsValid)
                {
                    // Calculate the total marks and update the result status
                    foreach (var exam in model.Questions)
                    {
                        if (model.SelectedOption != null && model.SelectedOption == exam.Answer)
                        {
                            model.ScoredMarks += exam.MarksPerQues;
                            if (model.ScoredMarks < model.Ques.ExamDetails.PassingMark)
                            {
                                obj.ResultStatus = "Pass";
                            }
                            else
                            {
                                obj.ResultStatus = "Fail";
                            }
                        }
                    }

                    *//*var result = new Result
                    {
                        ApplicationId = model.Result.ApplicationId,
                        ExamDetailsId = model.ExamDetails.ExamId,
                        ScoredMarks = model.Result.ScoredMarks,
                        ResultStatus = model.Result.ResultStatus
                    };*/
                    /*if (model.Ques.OptionA != null)
                    {

                        model.SelectedOption = model.Ques.OptionA;

                    }
                    else if (model.Ques.OptionB != null)
                    {
                        model.SelectedOption = model.Ques.OptionA;


                    }
                    else if (model.Ques.OptionC != null)
                    {
                        model.SelectedOption = model.Ques.OptionA;



                    }
                    else if (model.Ques.OptionD != null)
                    {
                        model.SelectedOption = model.Ques.OptionA;


                    }

                    if (model.SelectedOption.Equals(model.Ques.Answer))
                    {
                        model.ScoredMarks = model.ScoredMarks + model.Ques.MarksPerQues;

                    }


                    TempData.Keep();*//*
                    _unitOfWork.Result.Add(obj);
                    _unitOfWork.Save();

                    // Redirect to the result page
                    return RedirectToAction("Index");
                }
            }
            return View(model);
            *//* if (ModelState.IsValid)
             {
                 _unitOfWork.Result.Add(obj.Result);
                 _unitOfWork.Save();
                 TempData["success"] = "Exam completed Successfull.";
                 return RedirectToAction("Index");
             }
             return View(obj);*//*
        }*/

        public IActionResult Privacy()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}