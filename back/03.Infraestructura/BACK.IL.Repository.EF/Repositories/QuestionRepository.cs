using BACK.CORE.Entities;
using BACK.CORE.Interfaces.Repositories;
using BACK.CORE.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BACK.IL.Repository;

namespace BACK.IL.Repository.EF.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(Context context) : base(context) { }
        public Context? Context
        {
            get { return Context as Context; }
        }
       
    }
}
