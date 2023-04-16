using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Models.ViewModel
{
    public class QuestionVM
    {
        public Questions Questions { get; set; }
        //public string? SelectedAnswer { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ExamList { get; set; }

    }
}
