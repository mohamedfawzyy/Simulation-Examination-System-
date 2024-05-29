using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal abstract class BaseExam
    {
        public int Time { get; set; }
        public int NumOfQuestions { get; set; }

        public List<McqQuestion> McqQuestions { get; set; } = new List<McqQuestion>();

        public abstract BaseExam ShowExam();
        public abstract void CreateExamQuestions();
            
    }
}
