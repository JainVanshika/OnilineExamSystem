using System.ComponentModel.DataAnnotations;

namespace OnlineExam.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CategoryName { get; set; }
    }
}