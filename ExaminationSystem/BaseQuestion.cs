using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public abstract class BaseQuestion
    {
     

        public string QuestionHeader { get; set; }
        public string QuestionBody { get; set; }

        public double Mark { get; set; }

        public Answer RightAnswer { get; set; }
        public Answer UserAnswer { get; set; }

        protected BaseQuestion(string questionHeader)
        {
            QuestionHeader = questionHeader;
         
        }


    }
}
