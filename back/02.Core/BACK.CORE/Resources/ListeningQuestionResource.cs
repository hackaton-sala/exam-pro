using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Resources
{
    public class ListeningQuestionResource
    {
        public int ListeningQuestionId { get; set; }
        public int AudioUrl { get; set; }
        public string Question { get; set; }
        public string[] Options { get; set; }
        public string UserAnswer { get; set; }
        public string CorrectAnswer { get; set; }
    }
}