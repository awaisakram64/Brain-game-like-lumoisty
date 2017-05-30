using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        private int timeleft;
        private string time = "10:00";
        public int index = 0;
        int score = 0;
        int correct = 0;
        int wrong = 0;
        Color[] color = { Color.Black, Color.Orange, Color.Purple, Color.Yellow, Color.Blue, Color.Green, Color.Red };
        public Label[] label=new Label[16];
        public string[] label_name = { "Red", "Green", "Blue", "Yellow", "Purple", "Orange", "Black" };
        Random random = new Random();
        SpeechRecognitionEngine SRE = new SpeechRecognitionEngine();
        Choices choice = new Choices();
        GrammarBuilder gb = new GrammarBuilder();
        public Form1()
        {            
            InitializeComponent();
        }
        public int[] label_index = new int[16];
        public int[] color_index = new int[16];        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Show();
                Check_correct();
                label1.Text = "Speak Color of text Written";
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }                        
        }

        private void Check_correct()
        {
            maskedTextBox1.Text = time;
            string[] totaltime = maskedTextBox1.Text.Split(':');
            int min = Convert.ToInt32(totaltime[0]);
            int sec = Convert.ToInt32(totaltime[1]);
            timeleft = (min * 60) + sec;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            index = 0;
            choice.Add(new string[] { "Red", "Green", "Blue", "Yellow", "Purple", "Orange", "Black" });
            gb.Append(choice);
            Grammar grammar = new Grammar(gb);
            SRE.LoadGrammar(grammar);
            SRE.SetInputToDefaultAudioDevice();
            SRE.RecognizeAsync(RecognizeMode.Multiple);
            SRE.SpeechRecognized += SRE_SpeechRecognized;
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
                label1.Hide();
                MessageBox.Show("End" + "\nYour Score is: " + score + "\nWrong: " + wrong + "\nCorrect: " + correct);
            }    
        }
        void SRE_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            try
            {
                if (index < 15) 
                {
                    label[index].BackColor = Color.White;
                    if (label_name[color_index[index]] == e.Result.Text)
                    {
                        label[index].BackColor = Color.Green;
                        correct++;
                        score = score + 50;
                        index++;
                    }
                    else
                    {
                        label[index].BackColor = Color.Red;
                        wrong++;
                        score = score - 25;
                        index++;
                    }   
                }
                else
                {
                    timer1.Stop();
                    MessageBox.Show("End" + "\nYour Score is: " + score + "\nWrong: " + wrong + "\nCorrect: " + correct);

                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            label1.Hide();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
                    }

        private void Load_words()
        {
            index = 0;
            //listBox1.Items.Clear();
            //listBox2.Items.Clear();
            label_index = new int[16];
            color_index = new int[16];
            for (int i = 0; i < 16; i++)
            {
                flowLayoutPanel1.Controls.Remove(label[i]);
            }
            int c = 1;
            for (int i = 0; i < 16; i++)
            {
            A:
                int a = random.Next(0, 7);
                int b = random.Next(0, 7);
                label_index[i] = a;
                color_index[i] = b;
                label[i] = new Label();
                label[i].Size = new Size(100, 100);
                label[i].Text = label_name[a];
                // string text = "Color [" + label_name[a] + "]";
                label[i].ForeColor = Color.FromName(label_name[b]);
                if (label_name[b] == label_name[a])
                {
                    goto A;
                }
                if (i >= 1)
                {
                    if (label[i].Text == label[i - 1].Text)
                    {
                        goto A;
                    }
                }
                if (i >= 1)
                {
                    if (label[i].ForeColor == label[i - 1].ForeColor)
                    {
                        goto A;
                    }
                }
                label[i].Font = new Font("Times New Roman", 18);
            }
            foreach (var item in label)
            {
                flowLayoutPanel1.Controls.Add(item);
                if (c == 4)
                {
                    flowLayoutPanel1.SetFlowBreak(item, true);
                    c = 1;
                }
                else
                {
                    c++;
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            Load_words();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            timer1.Stop();
        }
    }
}
