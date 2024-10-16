using BACK.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Resources
{
    public class TextResource
    {
        public int TextId { get; set; }
        public string Content { get; set; }
        public string Level { get; set; }

        // Relación con los exámenes que usan el texto
        public ICollection<Exam> Exams { get; set; }
    }
    
    
}
