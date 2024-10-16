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
    public class TextRepository : Repository<Text>, ITextRepository
    {
        public TextRepository(DbContext context) : base(context)
        {
        }

        public Context? Context
        {
            get { return Context as Context; }
        }

        
    }
    
    
}
