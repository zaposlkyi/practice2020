using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace questWinForms
{
    public class Users
    {
        public static List<Users> allUsers;
        public string Name { get; set; }
        public int CountCorrectAnswers { get; set; }
        public int NumberOfPasses { get; set; }

        public Users()
        {
            Name = "";
            CountCorrectAnswers = 0;
            NumberOfPasses = 0;
        }

        public Users(string name, int countCorrectAnswers, int numberOfPasses)
        {
            Name = name;
            CountCorrectAnswers = countCorrectAnswers;
            NumberOfPasses = numberOfPasses;
        }

        public static void LoadUsers()
        {
            string res = "";
            string[] resSpl = new string[3];
            int num;
            int pas;
            allUsers = new List<Users>();
            using (Stream stream = new FileStream("users.txt", FileMode.OpenOrCreate))
            {
                using (StreamReader text = new StreamReader(stream, Encoding.UTF8))
                {
                    while (!text.EndOfStream)
                    {
                        res = text.ReadLine();
                        resSpl = res.Split(';');
                        num = int.Parse(resSpl[1]);
                        pas = int.Parse(resSpl[2]);
                        Users newUser = new Users(resSpl[0], num, pas);
                        allUsers.Add(newUser);
                    }
                }
            }
        }

        public static void SaveUser(Users user)
        {
            using(Stream stream = new FileStream("users.txt", FileMode.Append))
            {
                using (StreamWriter text = new StreamWriter(stream, Encoding.UTF8))
                {
                    text.WriteLine($"{user.Name};{user.CountCorrectAnswers};{user.NumberOfPasses};");
                }
            }
        }
        public static void SaveAllUsers(List<Users> users)
        {
            using (Stream stream = new FileStream("users.txt", FileMode.Create))
            {
                using (StreamWriter text = new StreamWriter(stream, Encoding.UTF8))
                {
                    for (int i = 0; i < users.Count; i++)
                    {
                        text.WriteLine($"{users[i].Name};{users[i].CountCorrectAnswers};{users[i].NumberOfPasses};");
                    }
                }
            }
        }
    }
}
