using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TFQuestion : Question
    {
        public TFQuestion(string body, double mark, Answer rightAnswer) : base("True or False Question", body, mark, new List<Answer> { new Answer(1, "True"), new Answer(2, "False") }, rightAnswer)
        {
        }

        public override string ToString()
        {
            return $"{this.header}   Mark({this.mark})\n" +
                     body + "\n" +
                     "1. True               2. False";
        }
    }
}
