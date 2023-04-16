using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Models;

namespace OnlineExamination.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ExamDetails> ExamDetails { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }    
        public DbSet<Result> results { get; set; }
    }
}
