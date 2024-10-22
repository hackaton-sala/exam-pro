using BACK.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Resources
{
    public class ExamResource
    {
        public int ExamId { get; set; }
        //public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string Level { get; set; }  // Nivel (A1, A2, etc.)
        public ExamType Type { get; set; } // Tipo: Grammar....
        public ICollection<ExamQuestion> Questions { get; set; }
    }
    
    
}
