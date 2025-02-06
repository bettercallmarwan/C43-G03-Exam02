using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class MCQQuestion : Question
    {
        public MCQQuestion(string body, double mark, List<Answer> answers, Answer rightAnswer) : base("MCQ Question", body, mark, answers, rightAnswer)
        {
        }

        public override string ToString()
        {
            return $"{this.header}   Mark({this.mark})\n" +
                     body + "\n" +
                     $"1. {answers[0].AnswerText}               2. {answers[1].AnswerText}               3. {answers[2].AnswerText}";
        }
    }
}
