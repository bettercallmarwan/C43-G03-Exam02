using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "Math");
            subject.createExam();

            Console.WriteLine("Do You Want To Start The Exam? (y | any other key): ");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "y")
            {
                Console.Clear();
                Stopwatch sw = Stopwatch.StartNew();
                subject.Exam.showExam();
                Console.WriteLine($"The Elapsed Time = {sw.Elapsed}");
            }
            else
            {
                Console.WriteLine("Exam cancelled.");
            }
        }
    }
}
