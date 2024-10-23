﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Entities.New
{
    public class Option
    {
        public int OptionId { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string OptionText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
