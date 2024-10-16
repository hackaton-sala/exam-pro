using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Resources
{
    public class QuestionResource
    {
        public int QuestionId { get; set; }
        public int IdExam { get; set; }
        public string TextQuestion { get; set; }
        public string CorrectAnswer { get; set; }
        public string UserAnswer { get; set; }
        public bool? IsCorrect { get; set; }  // Evaluación automática para gramática y reading
        public string Feedback { get; set; }   // Feedback personalizado
        public double? Score { get; set; } // Puntuación para adaptive learning
    
        // Relación con el examen
        //public Examen Examen { get; set; }
    }
}