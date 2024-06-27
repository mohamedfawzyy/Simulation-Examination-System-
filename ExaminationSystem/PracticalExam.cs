using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class PracticalExam : BaseExam
    {
        

        public override void CreateExamQuestions()
        {
            for (int i = 1; i <= this.NumOfQuestions; i++)
            {
             Console.Clear();
               
                
             McqQuestion mcqQuestion = this.CreateMCQQuestion();
             this.McqQuestions.Add(mcqQuestion);
                

            }
        }

        public override void ShowExam()
        {
            if (this.McqQuestions is not null && this.McqQuestions.Count > 0)
            {
                Console.WriteLine("==============================================");
                for (int i = 0; i < this.McqQuestions.Count; i++)
                {
                    Console.WriteLine($"{McqQuestions[i].QuestionHeader} \t Mark({McqQuestions[i].Mark})");
                    Console.WriteLine($"{McqQuestions[i].QuestionBody}");
                    foreach (var option in McqQuestions[i].answersOptions)
                    {

                        Console.Write($"{option.AnswerId}.{option.AnswerText} \t\t\t");
                    };
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------------------");
                    McqQuestions[i].UserAnswer = new Answer()
                    {
                        AnswerId = int.Parse(Console.ReadLine()),
                    };
                    switch (McqQuestions[i].UserAnswer.AnswerId)
                    {
                        case 1:
                            McqQuestions[i].UserAnswer.AnswerText = McqQuestions[i].answersOptions[0].AnswerText;
                            break;
                        case 2:
                            McqQuestions[i].UserAnswer.AnswerText = McqQuestions[i].answersOptions[1].AnswerText;
                            break;
                        case 3:
                            McqQuestions[i].UserAnswer.AnswerText = McqQuestions[i].answersOptions[2].AnswerText;
                            break;
                    }
                    if (McqQuestions[i].UserAnswer.Equals(McqQuestions[i].RightAnswer))
                    {
                        this.Grade += McqQuestions[i].Mark;
                    }
                }
            }
            this.ShowAnswers(null, this.McqQuestions,"practicalExam");
        }
    }
}
