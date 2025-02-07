using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Answer
    {
        #region Attributes
        private int answerId;
        private string answerText;
        #endregion

        #region Properties
        public int AnswerId { get => answerId; set => answerId = value; }
        public string? AnswerText { get => answerText; set => answerText = value; }
        #endregion


        public Answer(int answerId, string answerText)
        {
            this.answerId = answerId;
            this.answerText = answerText;
        }


        //public override bool Equals(object obj)
        //{
        //    if (obj is Answer other)
        //    {
        //        return this.AnswerText.Equals(other.AnswerText, StringComparison.OrdinalIgnoreCase);
        //    }
        //    return false;
        //}

        public override bool Equals(object obj)
        {
            if (obj is Answer other)
            {
                return this.AnswerText.Equals(other.AnswerText, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }
    }
}
