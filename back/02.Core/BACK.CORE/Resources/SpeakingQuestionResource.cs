using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Resources
{
    public class SpeakingQuestionResource
    {
        public int SpeakingQuestionId { get; set; }
        public string Question { get; set; }
        public string TextAnswer { get; set; }
        public string AudioAnswer { get; set; }
        
        public string Feedback { get; set; }
    }
}