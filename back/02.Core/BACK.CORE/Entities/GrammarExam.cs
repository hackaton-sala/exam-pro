using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Entities
{
    public class GrammarExam
    {
        public int IdExam { get; set; }
        //public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string Level { get; set; }  // Nivel (A1, A2, etc.)
        public ExamState State { get; set; } // Enum: Pendiente, Finalizado
        public ICollection<ExamQuestion> Questions { get; set; }
    }
    public enum ExamState
    {
        Pendiente,
        Finalizado
    }
}
