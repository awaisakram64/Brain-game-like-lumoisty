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
    public partial class Score : Form
    {
        public string[] array1 = new string[5];
        public string[] array2 = new string[5];
        public string[] array3 = new string[5];
        string connection = @"Data Source=AWAIS;Initial Catalog=BrainGames;Integrated Security=True";
        public Score()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Score_Load(object sender, EventArgs e)
        {
            /////////////////////////////////
            // For tab # 1
            ///////////////////////////////
            int a = 0;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select top(5) score from color_match order by score desc";
            cmd.CommandType = CommandType.Text;
            SqlDataReader redar = cmd.ExecuteReader();
            while (redar.Read())
            {
                array1[a++] = redar.GetInt32(0).ToString();
            }
            redar.Close();
            con.Close();
            label2.Text = "1.       " + array1[0];
            label3.Text = "2.       " + array1[1];
            label4.Text = "3.       " + array1[2];
            label5.Text = "4.       " + array1[3];
            label6.Text = "5.       " + array1[4];

            /////////////////////////////////
            // For tab # 1
            ///////////////////////////////
            int b = 0;
            SqlConnection con1 = new SqlConnection(connection);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;
            cmd1.CommandText = "select top(5) score from brain_shift order by score desc";
            cmd1.CommandType = CommandType.Text;
            SqlDataReader redar1 = cmd1.ExecuteReader();
            while (redar1.Read())
            {
                array2[b++] = redar1.GetInt32(0).ToString();
            }
            redar.Close();
            con.Close();
            label11.Text = "1.       " + array2[0];
            label10.Text = "2.       " + array2[1];
            label9.Text = "3.       " + array2[2];
            label8.Text = "4.       " + array2[3];
            label7.Text = "5.       " + array2[4];
            /////////////////////////////////
            // For tab # 3
            ///////////////////////////////
            int c = 0;
            SqlConnection con2 = new SqlConnection(connection);
            con2.Open();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con2;
            cmd2.CommandText = "select top(5) score from speak_color order by score desc";
            cmd2.CommandType = CommandType.Text;
            SqlDataReader redar2 = cmd2.ExecuteReader();
            while (redar2.Read())
            {
                array3[c++] = redar2.GetInt32(0).ToString();
            }
            redar.Close();
            con.Close();
            label17.Text = "1.       " + array3[0];
            label16.Text = "2.       " + array3[1];
            label15.Text = "3.       " + array3[2];
            label14.Text = "4.       " + array3[3];
            label13.Text = "5.       " + array3[4];

        }
    }
}
