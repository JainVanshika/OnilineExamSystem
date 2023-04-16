using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Models.ViewModel
{
    public class QuesResultVM
    {
        public IEnumerable<Questions> Questions { get; set; }
        public Questions Ques { get; set; }
        /*[ValidateNever]
        public Result Result { get; set; }*/
        /*[ValidateNever]
        public ExamDetails ExamDetails { get; set; }
        [Required]
        public ApplicationUser ApplicationUser { get; set; }
        [Required(ErrorMessage = "The SelectedOption field is required.")]*/
        public string? SelectedOption { get; set; }
        public int? ScoredMarks { get; set; }
    }
}
