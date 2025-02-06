using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int duration, int numberOfQuestions, List<Question> questions) : base(duration, numberOfQuestions, questions)
        {
        }


        private void displayExamHeader()
        {
            Console.WriteLine($"==========================================================================================================================================");
            Console.WriteLine($"==================================================(Practical Exam)========================================================================");
            Console.WriteLine($"==========================================================================================================================================");
            Console.WriteLine($"Exam Duration: {this.examDuration}                                                                          Number Of Questions: {this.numberOfQuestions} Question");
            Console.WriteLine($"==========================================================================================================================================");
            Console.WriteLine($"==========================================================================================================================================");
        }

        public override void showExam()
        {
            displayExamHeader();


            int entered_answer_int;
            List<Answer> entered_answer_list = new List<Answer>();
            double total_grade = 0, student_grade = 0;
            bool answerFlag;
            for(int i = 0; i < this.questions.Count; i++)
            {
                Console.WriteLine($"{i+1}. {questions[i]}");

                do
                {
                    Console.Write("Enter Answer: ");
                    answerFlag = int.TryParse(Console.ReadLine(), out entered_answer_int);
                } while (!answerFlag || (entered_answer_int != 1 && entered_answer_int != 2));

                string entered_answer_text = questions[i].Answers[entered_answer_int - 1].AnswerText;


                Answer student_answer = new Answer(entered_answer_int, entered_answer_text);
                entered_answer_list.Add(student_answer);

                if (student_answer.AnswerText.Equals(this.questions[i].RightAnswer.AnswerText, StringComparison.OrdinalIgnoreCase))
                {
                    student_grade += this.questions[i].Mark;
                }

                total_grade += this.questions[i].Mark;
            }

            Console.Clear();

            for (int i = 0; i < this.questions.Count; i++)
            {
                Console.WriteLine($"Q.{i+1} {questions[i].Body}");
                Console.WriteLine($"Entered answer: {entered_answer_list[i].AnswerText}");
                Console.WriteLine($"Correct answer: {this.questions[i].RightAnswer.AnswerText}");

                Console.WriteLine($"==================================================================================================================================================");
            }

            Console.WriteLine($"Your score is : {student_grade}/{total_grade}");
        }

        
    }
}
