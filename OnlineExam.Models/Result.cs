using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Models
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }
        [DisplayName("Result Status")]
        public string ResultStatus { get; set; }
        [DisplayName("Scored Marks")]
        public int ScoredMarks { get; set; }

        
        public string ApplicationId { get; set; }
        [ForeignKey("ApplicatinId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        [ValidateNever]
        public Questions Questions { get; set; }

        [Required]
        public int ExamDetailsId { get; set; }
        [ForeignKey("ExamDetailsId")]
        [ValidateNever]
        public ExamDetails ExamDetails { get; set; }
    }
}
