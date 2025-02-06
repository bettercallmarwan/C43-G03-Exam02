using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Question
    {
        #region Attributes
        private protected string header;
        private protected string body;
        private protected double mark;
        private protected List<Answer> answers;
        private protected Answer rightAnswer;
        #endregion

        #region Properties
        public string Header { get => header; set => header = value; }
        public string Body { get => body; set => body = value; }


        public double Mark { get => mark; set => mark = value; }
        public List<Answer> Answers { get => answers; set => answers = value; }
        public Answer RightAnswer { get => rightAnswer; set => rightAnswer = value; }
        #endregion

        #region Constructors
        public Question(string header, string body, double mark, List<Answer> answers, Answer rightAnswer)
        {
            this.header = header;
            this.body = body;
            this.mark = mark;
            this.answers = answers;
            this.rightAnswer = rightAnswer;
        }

        #endregion

        
    }
}
