using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Queries.OData
{
    public class OQuery<TEntity>
    {
        public IList<TEntity> Resultado { get; set; }
        public int TotalRegistros { get; set; }
    }
}
