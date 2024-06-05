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

        public double Grade { get; set; }
        public List<McqQuestion> McqQuestions { get; set; } = new List<McqQuestion>();

        public abstract void ShowExam();
        public abstract void CreateExamQuestions();

        public McqQuestion CreateMCQQuestion() 
        {
            McqQuestion McqQuestion = new McqQuestion("Choose One Answer Question");
            Console.WriteLine("Plaese Enter the Body of Question: ");
            McqQuestion.QuestionBody = Console.ReadLine();
            this.CreateMCQOptions(McqQuestion);
            Console.Write("Please Specify the Right Choice Question : ");
            McqQuestion.RightAnswer = new Answer();
            McqQuestion.RightAnswer.AnswerId = int.Parse(Console.ReadLine());
            if (McqQuestion.RightAnswer.AnswerId == 1)
            {
                McqQuestion.RightAnswer.AnswerText = McqQuestion.answersOptions[0].AnswerText;
            }
            else if (McqQuestion.RightAnswer.AnswerId == 2)
            {
                McqQuestion.RightAnswer.AnswerText = McqQuestion.answersOptions[1].AnswerText; 
            }
            else 
            {
                McqQuestion.RightAnswer.AnswerText = McqQuestion.answersOptions[2].AnswerText;
            }
            Console.Write("Please Enter The Marks of Question:");
            McqQuestion.Mark = double.Parse(Console.ReadLine());
            return McqQuestion;

        }


        private void CreateMCQOptions(McqQuestion mcqQuestion) {
            if (mcqQuestion == null) return;
            Console.WriteLine("The Choices of Questions");
            for (int i = 0; i < mcqQuestion.answersOptions.Length; i++)
            {
                Console.Write($"Please Enter The Choice Number {i+1}:");
                mcqQuestion.answersOptions[i]=new Answer();
                mcqQuestion.answersOptions[i].AnswerId = i+1;
                mcqQuestion.answersOptions[i].AnswerText = Console.ReadLine();
            }

        }
            
    }
}
