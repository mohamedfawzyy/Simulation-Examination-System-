using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class Subject
    {
        public int SubId { get; set; }
        public string SubName { get; set; }
        public BaseExam Exam { get; set; }
        public Subject(int Id , string Name)
        {
            this.SubId = Id;
            this.SubName = Name;    
        }
        public BaseExam CreateExam() {
            string ExamType;
            do
            {
                Console.Write("Please Enter The Type Of Exam You Want To Create (1 for Practical and 2 for Final): ");
                ExamType =Console.ReadLine();
            }
            while (!(ExamType == "1" || ExamType == "2"));
            
            if(ExamType  == "1")
               this.Exam = new PracticalExam();
            else
                this.Exam=new FinalExam();
            this.IntializeExamProperties(Exam);
            this.Exam.CreateExamQuestions();
            return Exam;
        }



        //set properties of exam
        private void IntializeExamProperties(BaseExam baseExam) {
            int Minutes, NumbersOfQuestions;
            bool flag1 , flag2;
            do
            {
                Console.Write("Please Enter The Time Of Exam in Minutes ex(60): ");
                flag1 = int.TryParse(Console.ReadLine(), out Minutes);
            } while (!flag1);
            do
            {
                Console.Write("Please Enter The number Of Questions you wanted To Create ex(2): ");
                flag2 = int.TryParse(Console.ReadLine(), out NumbersOfQuestions);
            
            } while (!flag2);

            baseExam.NumOfQuestions = NumbersOfQuestions;
            baseExam.Time = Minutes;
        }
        
    }
}
