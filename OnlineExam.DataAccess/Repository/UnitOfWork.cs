using OnlineExam.DataAccess.Migrations;
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
            Subject=new SubjectRepo(_context);
            ExamDetail = new ExamRepo(_context);
            questions= new QuestionRepo(_context);
            Result=new ResultRepo(_context);
            ApplicationUsers=new ApplicationUserRepo(_context);
        }

        public ICategoryRepo Category { get; private set; }

        public ISubjectRepo Subject{get;private set; }

        public IExamRepo ExamDetail { get; private set; }

        public IQuestionsRepo questions {get;private set; }

        public IResultRepo Result{get;private set; }

        public IApplicationUserRepo ApplicationUsers { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
