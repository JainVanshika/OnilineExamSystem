using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineExam.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
    }
}