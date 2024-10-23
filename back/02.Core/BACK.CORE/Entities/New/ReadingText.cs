using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Entities.New
{
    public class ReadingText
    {
        public int ReadingTextId { get; set; }
        public string EnglishLevel { get; set; }
        public string Text { get; set; }
        public string ExamType { get; set; }
        public string ExamPart { get; set; }
    }
}
