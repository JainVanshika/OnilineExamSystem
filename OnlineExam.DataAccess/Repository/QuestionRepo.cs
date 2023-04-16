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
    public class QuestionRepo:Repository<Questions>,IQuestionsRepo
    {
        private readonly ApplicationDbContext _context;
        public QuestionRepo(ApplicationDbContext context):base(context) 
        {
            _context= context;
        }

        public void Update(Questions obj)
        {
            _context.Questions.Update(obj);
        }
    }
}
