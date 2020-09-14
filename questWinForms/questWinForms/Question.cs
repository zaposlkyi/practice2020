using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace questWinForms
{
    public class Question
    {
        public static List<Question> allQuestions;
        public int QuestionNum { get; set; }
        public string MyQuestion { get; set; }

        Question()
        {
            MyQuestion = "";
            QuestionNum = -1;
            allQuestions = new List<Question>();
        }
        Question(int questionNum, string question)
        {
            QuestionNum = questionNum;
            MyQuestion = question;
        }

        public static void LoadQuestions()
        {
            string res;
            string[] resSpl = new string[3];
            int num;
            allQuestions = new List<Question>();
            using (Stream stream = new FileStream("questions.txt", FileMode.OpenOrCreate))
            {
                using (StreamReader text = new StreamReader(stream, Encoding.UTF8))
                {
                    while(!text.EndOfStream)
                    {
                        res = text.ReadLine();
                        resSpl = res.Split(';');
                        num = int.Parse(resSpl[0]);
                        Question newQuestion = new Question(num, resSpl[1]);
                        allQuestions.Add(newQuestion);
                    }
                }
            }
        }
    }
}
