using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepo Category { get; }
        ISubjectRepo Subject { get; }
        IExamRepo ExamDetail { get; }
        void Save();
    }
}
