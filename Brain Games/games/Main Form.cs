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

namespace WindowsFormsApplication8
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            label4.Text = "";
            circularProgress1.Enabled = false;
            panel1.Dock = DockStyle.Fill;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 1000;
           circularProgress1.Maximum = 10;
            timer1.Tick += new EventHandler(timer1_Tick);
        //      
        }
        public int count = 0;
        string[] loading = { "L", "o", "a", "d", "i", "n", "g", ".", ".", "." };
        private void timer1_Tick(object sender, EventArgs e)
        {           
            if (circularProgress1.Value != 10)
            {
                circularProgress1.Value++;
                label4.Text = label4.Text.ToString() + loading[count++].ToString();
            }
            else
            {
                timer1.Stop();
                panel1.Visible = false;
                panel6.Dock = DockStyle.Fill;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel6.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            color o = new color();
            o.ShowDialog();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            Color_Match o = new Color_Match();
            o.ShowDialog();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            Score o = new Score();
            o.ShowDialog();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Form1 o = new Form1();
            o.ShowDialog();
        }
    }
}
