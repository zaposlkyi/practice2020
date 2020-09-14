using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace questWinForms
{
    public partial class Form1 : Form
    {
        public static Button[] allQuestBtns = new Button[10];
        public static List<Question> questions = new List<Question>();
        public static List<Answer> answers = new List<Answer>();
        public static List<Users> users = new List<Users>();
        public static int correct = 0;
        public static int clickRight = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Question.LoadQuestions();
            Answer.LoadAnswers();
            users = Users.allUsers;
            int[] numberOfQuestions = new int[10];
            Random rnd = new Random();
            int num = 0;
            while (questions.Count != 10)
            {
                bool isSearched = false;
                num = rnd.Next(1, 11);
                for (int j = 0; j < numberOfQuestions.Length; j++)
                {
                    if (num == numberOfQuestions[j])
                    {
                        isSearched = true;
                        break;
                    }
                }
                if (!isSearched)
                {
                    questions.Add(Question.allQuestions[num - 1]);
                    answers.Add(Answer.allAnswers[num - 1]);
                    for (int i = 0; i < numberOfQuestions.Length; i++)
                    {
                        if (numberOfQuestions[i] == 0)
                        {
                            numberOfQuestions[i] = num;
                            break;
                        }
                    }
                }
            }

            labelNumQuest.Text = $"Вопрос №1";
            labelQuest.Text = questions[0].MyQuestion;
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[0].QuestionNum == Answer.allAnswers[i].QuestionNum)
                {
                    rBtnAns1.Text = Answer.allAnswers[i].FirstAns;
                    rBtnAns2.Text = Answer.allAnswers[i].SecondAns;
                    rBtnAns3.Text = Answer.allAnswers[i].ThirdAns;
                    rBtnAns4.Text = Answer.allAnswers[i].FourthAns;
                }
            }
            btnQuest1.BackColor = Color.LightBlue;
            allQuestBtns[0] = btnQuest1;
            allQuestBtns[1] = btnQuest2;
            allQuestBtns[2] = btnQuest3;
            allQuestBtns[3] = btnQuest4;
            allQuestBtns[4] = btnQuest5;
            allQuestBtns[5] = btnQuest6;
            allQuestBtns[6] = btnQuest7;
            allQuestBtns[7] = btnQuest8;
            allQuestBtns[8] = btnQuest9;
            allQuestBtns[9] = btnQuest10;
        }

        private void btnGoRight_Click(object sender, EventArgs e)
        {
            Users.LoadUsers();
            bool youAreRight = false;
            if (clickRight == 9)
            {
                if (textBox1.Text != "" && !textBox1.Text.Contains(';'))
                {
                    bool found = false;
                    for (int i = 0; i < Users.allUsers.Count; i++)
                    {
                        if (textBox1.Text == Users.allUsers[i].Name)
                        {
                            found = true;
                        }
                    }
                    if (rBtnAns1.Checked)
                    {
                        if (answers[9].CorrectAns == rBtnAns1.Text) youAreRight = true;
                        rBtnAns1.Checked = false;
                    }
                    else if (rBtnAns2.Checked)
                    {
                        if (answers[9].CorrectAns == rBtnAns2.Text) youAreRight = true;
                        rBtnAns2.Checked = false;
                    }
                    else if (rBtnAns3.Checked)
                    {
                        if (answers[9].CorrectAns == rBtnAns3.Text) youAreRight = true;
                        rBtnAns3.Checked = false;
                    }
                    else if (rBtnAns4.Checked)
                    {
                        if (answers[9].CorrectAns == rBtnAns4.Text) youAreRight = true;
                        rBtnAns4.Checked = false;
                    }
                    if (youAreRight)
                    {
                        allQuestBtns[9].BackColor = Color.Green;
                        correct++;
                    }
                    else allQuestBtns[9].BackColor = Color.Red;
                    if (!found)
                    {
                        Users user = new Users(textBox1.Text, correct, 1);
                        Users.SaveUser(user);
                        MessageBox.Show($"Your result: {user.CountCorrectAnswers} out of 10.", "End", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        for (int i = 0; i < Users.allUsers.Count; i++)
                        {
                            if(Users.allUsers[i].Name == textBox1.Text)
                            {
                                Users.allUsers[i].NumberOfPasses++;
                                Users.allUsers[i].CountCorrectAnswers = correct;
                                Users.SaveAllUsers(Users.allUsers);
                                MessageBox.Show($"Your result: {correct} out of 10.", "End", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введите ваше Ф.И.О в соответствующее поле или оно заполнено не верно.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                for (int i = 0; i < allQuestBtns.Length - 1; i++)
                {
                    if (allQuestBtns[i].BackColor == Color.LightBlue)
                    {
                        allQuestBtns[i + 1].BackColor = Color.LightBlue;
                        if (rBtnAns1.Checked)
                        {
                            if (answers[i].CorrectAns == rBtnAns1.Text) youAreRight = true;
                            rBtnAns1.Checked = false;
                        }
                        else if (rBtnAns2.Checked)
                        {
                            if (answers[i].CorrectAns == rBtnAns2.Text) youAreRight = true;
                            rBtnAns2.Checked = false;
                        }
                        else if (rBtnAns3.Checked)
                        {
                            if (answers[i].CorrectAns == rBtnAns3.Text) youAreRight = true;
                            rBtnAns3.Checked = false;
                        }
                        else if (rBtnAns4.Checked)
                        {
                            if (answers[i].CorrectAns == rBtnAns4.Text) youAreRight = true;
                            rBtnAns4.Checked = false;
                        }
                        if (youAreRight)
                        {
                            allQuestBtns[i].BackColor = Color.Green;
                            correct++;
                        }
                        else allQuestBtns[i].BackColor = Color.Red;
                        labelNumQuest.Text = $"Вопрос №{i + 2}";
                        labelQuest.Text = questions[i + 1].MyQuestion;
                        rBtnAns1.Text = answers[i + 1].FirstAns;
                        rBtnAns2.Text = answers[i + 1].SecondAns;
                        rBtnAns3.Text = answers[i + 1].ThirdAns;
                        rBtnAns4.Text = answers[i + 1].FourthAns;
                        clickRight++;
                        break;
                    }
                }
            }
        }

        private void btnTop_Click(object sender, EventArgs e)
        {
            Users.LoadUsers();
            Users tempUser = new Users();
            if (Users.allUsers.Count != 0)
            {
                for (int i = 0; i < Users.allUsers.Count; i++)
                {
                    for (int j = 0; j < Users.allUsers.Count; j++)
                    {
                        if (Users.allUsers[i].CountCorrectAnswers > Users.allUsers[j].CountCorrectAnswers)
                        {
                            tempUser = Users.allUsers[i];
                            Users.allUsers[i] = Users.allUsers[j];
                            Users.allUsers[j] = tempUser;
                        }
                    }
                }

                for (int i = 0; i < Users.allUsers.Count; i++)
                {
                    MessageBox.Show($"{Users.allUsers[i].Name}: {Users.allUsers[i].CountCorrectAnswers}/10. Passes: {Users.allUsers[i].NumberOfPasses}.", $"Место № {i + 1}");
                }
            }
            else
            {
                MessageBox.Show("Никто пока еще не поставил рекорд!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
