using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Subject
    {
        #region Attributes
        private int subjectId;
        private string? subjectName;
        private Exam exam;
        #endregion

        #region Properties
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public Exam Exam { get; set; }
        #endregion

        #region Methods
        public void createExam()
        {
            bool flag = false;
            int exam_type;
            Console.WriteLine("Enter Type Of Exam:\n(1) Practical\n(2) Final");

            do
            {
                Console.Write("Enter Valid Input: ");
                flag = int.TryParse(Console.ReadLine(), out exam_type);
            } while (!flag || (exam_type != 1 && exam_type != 2));
            Console.Clear();

            flag = false;
            int duration, number_of_questions;

            do
            {
                Console.Write("Enter Exam Duration (Minutes): ");
                flag = int.TryParse(Console.ReadLine(), out duration);
            } while (!flag || duration <= 0);
            Console.Clear();

            do
            {
                Console.Write("Enter Number Of Questions Of Exam (Minimum One Question): ");
                flag = int.TryParse(Console.ReadLine(), out number_of_questions);
            } while (!flag || number_of_questions <= 0);
            Console.Clear();

            List<Question> questions = new List<Question>();

            if (exam_type == 1)
            {
                for (int i = 0; i < number_of_questions; i++)
                {
                    string questionBody;
                    int mark;

                    do
                    {
                        Console.Write($"Enter Body Of Question #{i + 1}: ");
                        questionBody = Console.ReadLine();
                    } while (string.IsNullOrWhiteSpace(questionBody));

                    do
                    {
                        Console.Write("Enter Question Mark: ");
                        flag = int.TryParse(Console.ReadLine(), out mark);
                    } while (!flag || mark <= 0);

                    Console.WriteLine("The Choices Of The Question");
                    List<Answer> answers = new List<Answer>();

                    for (int j = 0; j < 3; j++)
                    {
                        string answer;
                        do
                        {
                            Console.Write($"Enter Choice Number #{j + 1}: ");
                            answer = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(answer));

                        answers.Add(new Answer(j + 1, answer));
                    }

                    int right_answer_Id;
                    do
                    {
                        Console.Write("Enter Right Answer (1, 2, 3): ");
                        flag = int.TryParse(Console.ReadLine(), out right_answer_Id);
                    } while (!flag || (right_answer_Id < 1 || right_answer_Id > 3));

                    Answer rightAnswer = answers[right_answer_Id - 1];
                    MCQQuestion question = new MCQQuestion(questionBody, mark, answers, rightAnswer);
                    questions.Add(question);
                    Console.Clear();
                }
                Exam = new PracticalExam(duration, number_of_questions, questions);
            }
            else
            {
                for (int i = 0; i < number_of_questions; i++)
                {
                    int question_type;
                    do
                    {
                        Console.WriteLine("Enter Question Type:\n(1) True or False\n(2) MCQ");
                        flag = int.TryParse(Console.ReadLine(), out question_type);
                    } while (!flag || (question_type != 1 && question_type != 2));
                    Console.Clear();

                    string questionBody;
                    int mark;

                    do
                    {
                        Console.Write($"Enter Body Of Question #{i + 1}: ");
                        questionBody = Console.ReadLine();
                    } while (string.IsNullOrWhiteSpace(questionBody));

                    do
                    {
                        Console.Write("Enter Question Mark: ");
                        flag = int.TryParse(Console.ReadLine(), out mark);
                    } while (!flag || mark <= 0);

                    if (question_type == 1)
                    {
                        int right_answer_Id;
                        do
                        {
                            Console.WriteLine("Enter Right Answer:\n(1) True\n(2) False");
                            flag = int.TryParse(Console.ReadLine(), out right_answer_Id);
                        } while (!flag || (right_answer_Id != 1 && right_answer_Id != 2));
                        Console.Clear();

                        string right_answer_text = right_answer_Id == 1 ? "True" : "False";
                        Answer rightAnswer = new Answer(right_answer_Id, right_answer_text);
                        questions.Add(new TFQuestion(questionBody, mark, rightAnswer));
                    }
                    else 
                    {
                        Console.WriteLine("The Choices Of The Question");
                        List<Answer> answers = new List<Answer>();

                        for (int j = 0; j < 3; j++)
                        {
                            string answer;
                            do
                            {
                                Console.Write($"Enter Choice Number #{j + 1}: ");
                                answer = Console.ReadLine();
                            } while (string.IsNullOrWhiteSpace(answer));

                            answers.Add(new Answer(j + 1, answer));
                        }

                        int right_answer_Id;
                        do
                        {
                            Console.Write("Enter Right Answer (1, 2, 3): ");
                            flag = int.TryParse(Console.ReadLine(), out right_answer_Id);
                        } while (!flag || (right_answer_Id < 1 || right_answer_Id > 3));

                        Answer rightAnswer = answers[right_answer_Id - 1];
                        questions.Add(new MCQQuestion(questionBody, mark, answers, rightAnswer));
                        Console.Clear();
                    }
                }
                Exam = new FinalExam(duration, number_of_questions, questions);
            }
        }

        #endregion
        public Subject(int id, string name)
        {
            this.subjectId = id;
            this.subjectName = name;
        }
    }
}