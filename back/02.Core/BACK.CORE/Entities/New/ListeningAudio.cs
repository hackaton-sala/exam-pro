using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Entities.New
{
    public class ListeningAudio
    {
        public int ListeningAudioId { get; set; }
        public string EnglishLevel { get; set; }
        public string AudioUrl { get; set; }
        public string ExamType { get; set; }
        public string ExamPart { get; set; }
    }
}
