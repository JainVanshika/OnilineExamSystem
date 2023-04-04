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
    public class ExamRepo : Repository<ExamDetails>, IExamRepo
    {
        private readonly ApplicationDbContext _context;
        public ExamRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(ExamDetails obj)
        {
            var editExam = _context.ExamDetails.FirstOrDefault(u => u.ExamId == obj.ExamId);
            if (editExam != null)
            {
                editExam.CategoryId = obj.CategoryId;
                editExam.SubjectId = obj.SubjectId;
                editExam.Name = obj.Name;
                editExam.Description = obj.Description;
                editExam.ExamDate = obj.ExamDate;
                editExam.ExamDuration = obj.ExamDuration;
                editExam.PassingMark = obj.PassingMark;
                editExam.TotalMark = obj.TotalMark;
            }
        }
    }
}
