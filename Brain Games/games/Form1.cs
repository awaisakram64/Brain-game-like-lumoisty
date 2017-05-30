using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;
using System.Data.SqlClient;


namespace WindowsFormsApplication8
{
    
    public partial class color : Form
    {
      //  object 
        string connection = @"Data Source=AWAIS;Initial Catalog=BrainGames;Integrated Security=True";
        SpeechRecognitionEngine SRE = new SpeechRecognitionEngine();
        Choices choice = new Choices();
        GrammarBuilder gb = new GrammarBuilder();
        public int correct = 0;
        public int score = 0;
        public int wrong = 0;
        private int timeleft;
        private string time = "10:00";
        Random rand = new Random();
        public color()
        {
            InitializeComponent();
        }
        public void lablechanger()
        {
            int a = rand.Next(0, 2);
            if (a == 1)
            {
                lable1();
            }
            else 
            {
                lable2();
            }   
        }
        private void button3_Click(object sender, EventArgs e)
        {
            panel6.Hide();
            pictureBox1.Hide(); 
            maskedTextBox1.Text = time;
            button1.Enabled = true;
            button2.Enabled = true;
            button4.Enabled = true;
            button3.Enabled = false;
            lablechanger();             
            string [] totaltime = maskedTextBox1.Text.Split(':');
            int min = Convert.ToInt32(totaltime[0]);
            int sec = Convert.ToInt32(totaltime[1]);
            timeleft = (min * 60) + sec;           
            timer1.Tick += new EventHandler(timer1_Tick);        
            timer1.Start();
            choice.Add(new string[] { "yes", "no"});
            gb.Append(choice);
            Grammar grammar = new Grammar(gb);
            SRE.LoadGrammar(grammar);
         //   SRE.SetInputToDefaultAudioDevice();
           // SRE.RecognizeAsync(RecognizeMode.Multiple);
            //SRE.SpeechRecognized+=SRE_SpeechRecognized;
        }

        private void color_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Left)
            {
                try
                {
                    if (label1.Text == "")
                    {
                        lable2correct();
                        lablechanger();
                        LocationChanger();
                    }
                    else
                    {
                        lable1correct();
                        lablechanger();
                        LocationChanger();
                    }
                    label4.Text = score.ToString();
                }
                catch (Exception a)
                {
                    MessageBox.Show("Error in button Y:" + a.Message);
                }            
            }
            else if(e.KeyCode==Keys.Right)
            {
                try
                {
                    if (label2.Text == "")
                    {
                        lable1NotCorrect();
                        lablechanger();
                        LocationChanger();
                    }
                    else
                    {
                        lable2NotCorrect();
                        lablechanger();
                        LocationChanger();
                    }
                    label4.Text = score.ToString();
                }

                catch (Exception a)
                {
                    MessageBox.Show("Error in button N:" + a.Message);
                }      
            }
        }        

        private void SRE_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text=="yes")
            {
                try
                {
                    if (label1.Text == "")
                    {
                        lable2correct();
                        lablechanger();
                        LocationChanger();
                    }
                    else
                    {
                        lable1correct();
                        lablechanger();
                        LocationChanger();
                    }
                    label4.Text = score.ToString();
                }
                catch (Exception a)
                {
                    MessageBox.Show("Error in button Y:" + a.Message);
                }           
            }
            else if (e.Result.Text=="no")
            {
                try
                {
                    if (label2.Text == "")
                    {
                        lable1NotCorrect();
                        lablechanger();
                        LocationChanger();
                    }
                    else
                    {
                        lable2NotCorrect();
                        lablechanger();
                        LocationChanger();
                    }
                    label4.Text = score.ToString();
                }

                catch (Exception a)
                {
                    MessageBox.Show("Error in button N:" + a.Message);
                }
            }
        }
        public void lable1()
        {
            label1.Text = Convert.ToString(rand.Next(1, 10));
            label7.Text = Convert.ToString(GetLetter());
            label8.Text = "";
            label2.Text = "";
        }
        public void lable2()
        {
            label2.Text = Convert.ToString(GetLetter());
            label8.Text = Convert.ToString(rand.Next(1, 10));
            label1.Text = "";
            label7.Text = "";
        }
        public static char GetLetter()
        {
            Random random = new Random();
            // This method returns a random lowercase letter
            // ... Between 'a' and 'z' inclusize.
            int num = random.Next(0, 21); // Zero to 25
            char let = (char)('A' + num);
            return let;            
        }
        public void lable1correct()
        {
            try
            {
                if (Convert.ToInt32(label1.Text) % 2 == 0)
                {
                    score = score + 50;
                    correct = correct + 1;
                }
                else
                {
                    score = score - 25;
                    wrong = wrong + 1;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Error in lable1correct(): " + a.Message);
            }           
        }
        public void lable1NotCorrect()
        {
            try
            {
                if (Convert.ToInt32(label1.Text) % 2 == 0)
                {
                    score = score - 25;
                    wrong = wrong + 1;
                }
                else
                {
                    score = score + 50;
                    correct = correct + 1;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Error in lable1correct(): " + a.Message);
            }
        }
        public void lable2correct()
        {
            try
            {
                if (label2.Text == "A" || label2.Text == "E" || label2.Text == "I" || label2.Text == "O" || label2.Text == "U")
                {
                    score = score + 50;
                    correct = correct + 1;
                }
                else
                {
                    score = score - 25;
                    wrong = wrong + 1;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Error in lable2correct(): " + a.Message);
            }
        }
        public void lable2NotCorrect()
        {
            try
            {
                if (label2.Text == "A" || label2.Text == "E" || label2.Text == "I" || label2.Text == "O" || label2.Text == "U")
                {
                    score = score - 25;
                    wrong = wrong + 1;
                }
                else
                {
                    score = score + 50;
                    correct = correct + 1;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Error in lable2correct(): " + a.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {                
                if (label1.Text == "")
                {
                    lable2correct();
                    lablechanger();
                    LocationChanger();
                }
                else
                {
                    lable1correct();
                    lablechanger();
                    LocationChanger();
                }
                label4.Text = score.ToString();
            }
            catch (Exception a)
            {
                MessageBox.Show("Error in button Y:" + a.Message);
            }           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (label2.Text == "")
                {
                    lable1NotCorrect();
                    lablechanger();
                    LocationChanger();
                }
                else
                {
                    lable2NotCorrect();
                    lablechanger();
                    LocationChanger();
                }
                label4.Text = score.ToString();
            }

            catch (Exception a)
            {
                MessageBox.Show("Error in button N:" + a.Message);
            }                
        }
        private void button4_Click(object sender, EventArgs e)
        {            
            button3.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = false;
            timer1.Stop();            
            MessageBox.Show("Your Score is: " + score+"\n Correct : "+correct+"\n Wrong : "+wrong);
            correct = 0;
            score = 0;            
            wrong = 0;
            label4.ResetText();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label6.Hide();
            maskedTextBox1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            label4.Text = "0";
            maskedTextBox1.Text = time;                    
        }
        private void button5_Click(object sender, EventArgs e)
        {
           
        }
        public void LocationChanger()
        {
            int a = rand.Next(0, 2);
            if (a==0)
            {
                label1.Location = new Point(7, 8);
                label7.Location = new Point(35, 8);
                label2.Location = new Point(198, 228);
                label8.Location = new Point(227, 228);
            }
            else if (a==1)
            {
                label1.Location = new Point(35, 8);
                label7.Location = new Point(7, 8);
                label2.Location = new Point(227, 228);
                label8.Location = new Point(198, 228);
            }            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {            
            if (timeleft>0)
            {
                timeleft = timeleft - 1;
                var timespan = TimeSpan.FromSeconds(timeleft);
                maskedTextBox1.Text = timespan.ToString(@"mm\:ss");
            }
            else
            {
                button3.Enabled = true;
                timer1.Stop();
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into brain_shift(score) values('" + score + "')";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("End"+"\nYour Score is: "+score+"\nWrong: "+wrong+"\nCorrect: "+correct);  
                correct = 0;
                score = 0;
                wrong = 0;
                label4.ResetText();
            }            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //panel5.Show();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            panel6.Show();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            panel6.Hide();
        }

        private void button3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 49 && e.KeyChar <= 50)
            {
                MessageBox.Show("Form.KeyPress: '" + e.KeyChar.ToString() + "' pressed.");
            }
        }

        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                MessageBox.Show("hello");
            }   
        }
    }
}
