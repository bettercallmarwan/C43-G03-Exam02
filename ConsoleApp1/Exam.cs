using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal abstract class Exam
    {
        #region Attributes
        private protected int examDuration;
        private protected int numberOfQuestions;
        private protected List<Question> questions;


        #endregion

        #region Properties
        public int ExamDuration { get => examDuration; set => examDuration = value; }
        public int NumberOfQuestions { get => numberOfQuestions; set => numberOfQuestions = value; }
        public List<Question> Questions { get => questions; set => questions = value; }
        #endregion

        public Exam(int duration, int numberOfQuestions, List<Question> questions)
        {
            this.examDuration = duration;
            this.numberOfQuestions = numberOfQuestions;
            this.questions = questions;
        }

        #region Methods
        public abstract void showExam();


        #endregion
    }
}
