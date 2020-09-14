using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace questWinForms
{
    public class Answer
    {
        public int QuestionNum { get; set; }
        public string FirstAns { get; set; }
        public string SecondAns { get; set; }
        public string ThirdAns { get; set; }
        public string FourthAns { get; set; }
        public string CorrectAns { get; set; }
        public static List<Answer> allAnswers;

        Answer()
        {
            allAnswers = new List<Answer>();
            QuestionNum = -1;
            FirstAns = "";
            SecondAns = "";
            ThirdAns = "";
            FourthAns = "";
            CorrectAns = "";
        }

        Answer(int questionNum, string firstAns, string secondAns, string thirdAns, string fourthAns, string correctAns)
        {
            QuestionNum = questionNum;
            FirstAns = firstAns;
            SecondAns = secondAns;
            ThirdAns = thirdAns;
            FourthAns = fourthAns;
            CorrectAns = correctAns;
        }

        public static void LoadAnswers()
        {
            string res = "";
            string[] resSpl = new string[6];
            int num;
            allAnswers = new List<Answer>();
            using (Stream stream = new FileStream("answers.txt", FileMode.OpenOrCreate))
            {
                using (StreamReader text = new StreamReader(stream, Encoding.UTF8))
                {
                    while (!text.EndOfStream)
                    {
                        res = text.ReadLine();
                        resSpl = res.Split(';');
                        num = int.Parse(resSpl[0]);
                        Answer newAnswer = new Answer(num, resSpl[1], resSpl[2], resSpl[3], resSpl[4], resSpl[5]);
                        allAnswers.Add(newAnswer);
                    }
                }
            }
        }
    }
}
