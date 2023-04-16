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
    public class Questions
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Question")]
        public string Ques { get; set; }

        [Required]
        [DisplayName("Option A")]
        public string OptionA { get; set; }
        [Required]
        [DisplayName("Option B")]
        public string OptionB { get; set; }
        [Required]
        [DisplayName("Option C")]
        public string OptionC { get; set; }
        [Required]
        [DisplayName("Option D")]
        public string OptionD { get; set; }

        [Required]
        [DisplayName("Correct Answer")]
        public string Answer { get; set; }

        [Required]
        public int ExamsId { get; set; }
        [ForeignKey("ExamsId")]
        [ValidateNever]
        public ExamDetails ExamDetails { get; set; }

        [Required]
        [DisplayName("Marks for this Question")]
        public int MarksPerQues { get; set; }

        //public string? SelectedAnswer { get; set; }
    }
}
