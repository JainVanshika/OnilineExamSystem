using OnlineExam.DataAccess.Repository.IRepository;
using OnlineExam.Models;
using OnlineExamination.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.DataAccess.Repository
{
    public class CategoryRepo : Repository<Category>, ICategoryRepo
    {
        private ApplicationDbContext _context;
        public CategoryRepo(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public void Update(Category obj)
        {
            _context.Update(obj);
        }
    }
}
