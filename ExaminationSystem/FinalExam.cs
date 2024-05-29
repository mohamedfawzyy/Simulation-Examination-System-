using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class FinalExam : BaseExam
    {
        public List<TFQuestion> TFQuestions { get; set; } = new List<TFQuestion>();

        public override void CreateExamQuestions()
        {
            for (int i = 1; i <= this.NumOfQuestions; i++) {
                Console.Clear();
                string QuestionType;
                do
                {
                    Console.Write($"Please Choose The Type Of Question Number({i})(1 for True OR False || 2 for MCQ) :");
                    QuestionType = Console.ReadLine();
                } while (!(QuestionType == "1" || QuestionType == "2"));

                if (QuestionType == "1")
                {
                    TFQuestion tFQuestion = this.BuildTFQuestion();
                    this.TFQuestions.Add(tFQuestion);
                }
                else { 
                
                    //tomorrow will continue;
                }
               
            }
        }

        private TFQuestion BuildTFQuestion() {

            TFQuestion tFQuestion = new TFQuestion("True | False Question");
            Console.Write("Plaese Enter the Body of Question ");
            tFQuestion.QuestionBody = Console.ReadLine();
            Console.Write("Please Enter The Marks of Question:");
            tFQuestion.Mark = double.Parse(Console.ReadLine());
            Console.Write("Please Enter The Right Answer of Question of (1 for true and 2 for false): ");
            tFQuestion.RightAnswer = new Answer();
            tFQuestion.RightAnswer.AnswerId = int.Parse(Console.ReadLine());
            if (tFQuestion.RightAnswer.AnswerId == 1)
            {
                tFQuestion.RightAnswer.AnswerText = "true";
            }
            else
            {
                tFQuestion.RightAnswer.AnswerText = "false";
            }
            return tFQuestion;
        }
        public override BaseExam ShowExam()
        {
            throw new NotImplementedException();
        }
    }
}
