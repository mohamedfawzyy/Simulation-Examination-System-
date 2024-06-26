﻿using System.Diagnostics;

namespace ExaminationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "DS");
            subject.CreateExam();
            Console.Clear();
            Console.Write("Do you want to Start Exam(y|n): ");

            if (char.Parse(Console.ReadLine()) == 'y') { 
                Console.Clear() ;
                var timer = new Stopwatch();
                timer.Start();
                subject.Exam.ShowExam();
                timer.Stop();
                TimeSpan timeTaken = timer.Elapsed;
                Console.WriteLine($"your time is {timeTaken}");
            }
        
        }
    }
}
