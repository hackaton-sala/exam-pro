using BACK.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using BACK.CORE.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.IL.Repository.EF.Repositories
{
    public class ExamRepository : Repository<Exam>, IExamRepository
    {
        public ExamRepository(DbContext context) : base(context)
        {
        }

        public Context? Context
        {
            get { return Context as Context; }
        }

        
    }
    
    
}
