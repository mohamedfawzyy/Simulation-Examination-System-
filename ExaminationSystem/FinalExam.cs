using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                    McqQuestion mcqQuestion = this.CreateMCQQuestion();
                    this.McqQuestions.Add(mcqQuestion);
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
        public override void ShowExam()
        {
            if (this.TFQuestions is not null && this.TFQuestions.Count > 0) {

                for (int i = 0; i < this.TFQuestions.Count; i++)
                {
                    Console.WriteLine($"{TFQuestions[i].QuestionHeader} \t Mark({TFQuestions[i].Mark})");
                    Console.WriteLine($"{TFQuestions[i].QuestionBody}");
                    Console.WriteLine("1.True\t\t\t\t2.False");
                    Console.WriteLine("--------------------------------------------");
                    TFQuestions[i].UserAnswer = new Answer()
                    {
                        AnswerId = int.Parse(Console.ReadLine()),
                    };
                    TFQuestions[i].UserAnswer.AnswerText = TFQuestions[i].UserAnswer.AnswerId == 1 ? "true" : "false";
                    if (TFQuestions[i].UserAnswer.Equals(TFQuestions[i].RightAnswer)) {

                        this.Grade+=TFQuestions[i].Mark;
                    }
                }
            }

            if (this.McqQuestions is not null && this.McqQuestions.Count > 0)
            {
                Console.WriteLine("==============================================");
                for (int i = 0; i < this.McqQuestions.Count; i++)
                {
                    Console.WriteLine($"{McqQuestions[i].QuestionHeader} \t Mark({McqQuestions[i].Mark})");
                    Console.WriteLine($"{McqQuestions[i].QuestionBody}");
                    foreach (var option in McqQuestions[i].answersOptions) {

                        Console.Write($"{option.AnswerId}.{option.AnswerText} \t\t\t");
                    };
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------------------");
                    McqQuestions[i].UserAnswer = new Answer()
                    {
                        AnswerId = int.Parse(Console.ReadLine()),
                    };
                    switch (McqQuestions[i].UserAnswer.AnswerId) {
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
            this.ShowAnswers(this.TFQuestions,this.McqQuestions,"finalExam");
        }
    }
}
