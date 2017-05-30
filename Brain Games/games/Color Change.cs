using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication8
{
    public partial class Color_Match : Form
    {
        string connection = @"Data Source=AWAIS;Initial Catalog=BrainGames;Integrated Security=True";
        private int timeleft;
        private string time = "10:00";
        int score = 0;
        int correct = 0;
        int wrong = 0;
        /// <summary>
        /// Correct For lable 1
        /// </summary>
        /// 

        public string[,] true_lab1 = { { "Yellow", "Red" },
                                     { "Red", "Red" },
                                     { "Blue", "Black" },
                                     { "Yellow", "Red" },
                                     { "Blue", "yellow" },
                                     { "Red", "Red" },
                                     { "Blue", "Yellow" },
                                     { "Yellow", "Yellow" },
                                     { "Black", "Red" }};
        /// <summary>
        /// Correct For lable 2
        /// </summary>
        public string[,] true_lab2 = { { "Yellow", "Yellow" },
                                     { "Black", "Red" },
                                     { "Yellow", "Blue" },
                                     { "Red", "Yellow" },
                                     { "Red", "Blue" },
                                     { "yellow", "Red" },
                                     { "Red", "Blue" },
                                     { "Yellow", "Yellow" },
                                     { "Blue", "Black" }};

        public string [,] lab1 = { { "Red", "Black" },
                                 { "Black", "Black" },
                                 {"Blue","Black"},
                                 {"Blue","Black"},
                                 {"Black","Black"},
                                 {"Red","Red"},
                                 {"Red","Black"},
                                 {"Black","Black"},
                                 {"Red","Black"},
                                 {"Black","Black"},
                                 {"Yellow","Black"},
                                 {"Blue","Red"},
                                 {"Red","Black"},
                                 {"Red","Yellow"},
                                 {"Blue","Black"},
                                 {"Yellow","Black"},
                                 {"Yellow","Black"},
                                 {"Red","Black"},
                                 {"Blue","Black"},
                                 {"Yellow","Black"},
                                 {"Blue","Yellow"},
                                 {"Yellow","Black"},
                                 {"Blue","Red"},
                                 {"Red","Black"},
                                 {"Blue","Black"},
                                 {"Blue","Black"},
                                 {"Red","Yellow"},
                                 {"Blue","Red"},
                                 {"Red","Black"},
                                 {"Blue","Black"},
                                 {"Black","Yellow"},
                                 {"Yellow","Black"},
                                 {"Black","Red"},
                                 {"Yellow","Black"},};
        /// <summary>
        /// Next 
        /// </summary>

        public string[,] lab2 = { { "Red", "Black" },
                                 { "Black", "Black" },
                                 {"Blue","Black"},
                                 {"Blue","Black"},
                                 {"Black","Black"},
                                 {"Red","Red"},
                                 {"Red","Black"},
                                 {"Black","Black"},
                                 {"Red","Black"},
                                 {"Black","Black"},
                                 {"Yellow","Black"},
                                 {"Blue","Red"},
                                 {"Red","Black"},
                                 {"Red","Yellow"},
                                 {"Blue","Black"},
                                 {"Yellow","Black"},
                                 {"Yellow","Black"},
                                 {"Red","Black"},
                                 {"Blue","Black"},
                                 {"Yellow","Black"},
                                 {"Blue","Yellow"},
                                 {"Yellow","Black"},
                                 {"Blue","Red"},
                                 {"Red","Black"},
                                 {"Blue","Black"},
                                 {"Blue","Black"},
                                 {"Red","Yellow"},
                                 {"Blue","Red"},
                                 {"Red","Black"},
                                 {"Blue","Black"},
                                 {"Black","Yellow"},
                                 {"Yellow","Black"},
                                 {"Black","Red"},
                                 {"Yellow","Black"},};
        public string [] color_name = { "Red", "Blue", "Yellow", "Black" };        
        Random rand = new Random();
        Color[] color = { Color.Red, Color.Blue, Color.FromArgb(230, 230, 0), Color.Black };        
        public Color_Match()
        {
            InitializeComponent();            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label6.Hide();
            label1.Text = "";
            label2.Text = "";
            button4.Enabled = false;
            button3.Enabled = false;
            button2.Enabled = false;
            maskedTextBox1.Enabled = false;
        }                      
        private void button1_Click(object sender, EventArgs e)
        {
            panel6.Hide();
            pictureBox1.Hide();
            button1.Enabled = false;
            button4.Enabled = true;
            button3.Enabled = true;
            button2.Enabled = true;
            maskedTextBox1.Text = time;
            string[] totaltime = maskedTextBox1.Text.Split(':');
            int min = Convert.ToInt32(totaltime[0]);
            int sec = Convert.ToInt32(totaltime[1]);
            timeleft = (min * 60) + sec;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            text_change();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeleft > 0)
            {
                timeleft = timeleft - 1;
                var timespan = TimeSpan.FromSeconds(timeleft);
                maskedTextBox1.Text = timespan.ToString(@"mm\:ss");
            }
            else
            {                
                timer1.Stop();
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText="insert into color_match(score) values('"+score+"')";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("End" + "\nYour Score is: " + score + "\nWrong: " + wrong + "\nCorrect: " + correct);
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            timer1.Stop();
            MessageBox.Show("Your Score is: " + score + "\n Correct : " + correct + "\n Wrong : " + wrong);
        }
        string lab1_mean = "";
        string lab2_color = "";
        private void text_change()
        {
            int chos;
            chos = rand.Next(0, 2);
            if (chos==0)
            {
                int b = rand.Next(0, 9);
                label1.Text = true_lab1[b, 0];
                label1.ForeColor = Color.FromName(true_lab1[b, 1]);
                lab1_mean = true_lab1[b, 0];
                label2.Text = true_lab2[b, 0];
                label2.ForeColor = Color.FromName(true_lab2[b, 1]);
                lab2_color = true_lab2[b, 1];
            }
            else if (chos == 1)
            {
                int a;
                a = rand.Next(0, 34);
                label1.Text = lab1[a, 0];
                label1.ForeColor = Color.FromName(lab1[a, 1]);
                lab1_mean = lab1[a, 0];
                int b;
                b = rand.Next(0, 34);
                label2.Text = lab1[b, 0];
                label2.ForeColor = Color.FromName(lab1[b, 1]);
                lab2_color = lab1[b, 1];
            }           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yes_click();
            text_change();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            No_click();
            text_change();
        }
        private void No_click()
        {
            if (lab1_mean == lab2_color)
            {
                score = score - 25;
                wrong++;
                label5.Text = score.ToString();
            }
            else
            {
                correct++;
                score = score + 50;
                label5.Text = score.ToString();
            }
        } 
        private void yes_click()
        {
            if (lab1_mean == lab2_color)
            {
                score = score + 50;
                correct++;
                label5.Text = score.ToString();
            }
            else
            {
                score = score - 25;
                wrong++;
                label5.Text = score.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Close();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            panel6.Show();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            panel6.Hide();
        }        
    }
}
