using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Models
{
    public class ExamDetails
    {
        [Key]
        public int ExamId { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [Required]
        public int SubjectId { get; set; }
        [ValidateNever]
        public Subject Subject { get; set; }

        [Required]
        [DisplayName("Exam Name")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DisplayName("Exam Date")]
        [DataType(DataType.Date)]
        public DateTime ExamDate { get; set; }

        [Required]
        [DisplayName("Exam Duration")]
        [DataType(DataType.Duration)]
        public TimeSpan ExamDuration { get; set; }

        [Required]
        [DisplayName("Exam Passing Marks")]
        public int PassingMark { get; set; }

        [Required]
        [DisplayName("Exam Total Marks")]
        public int TotalMark { get; set; }
    }
}
