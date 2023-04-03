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
    public class SubjectRepo:Repository<Subject>, ISubjectRepo
    {
        private ApplicationDbContext _context;
        public SubjectRepo(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public void Update(Subject obj)
        {
            _context.Update(obj);
        }
    }
}
