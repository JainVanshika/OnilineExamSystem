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
    public class ResultRepo:Repository<Result>,IResultRepo
    {
        private ApplicationDbContext _context;
        public ResultRepo(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }
    }
}
