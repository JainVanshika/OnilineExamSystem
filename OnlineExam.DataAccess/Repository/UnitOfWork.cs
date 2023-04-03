using OnlineExam.DataAccess.Repository.IRepository;
using OnlineExamination.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.DataAccess.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category=new CategoryRepo(_context);
        }

        public ICategoryRepo Category { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
