using OnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.DataAccess.Repository.IRepository
{
    public interface IExamRepo : IRepository<ExamDetails>
    {
        void Update(ExamDetails obj);
    }
}
