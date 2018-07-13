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

namespace OOP2
{
    public partial class UpdateDB : Form
    {
        Form obj;
        string selectedFile;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Rai_Sul\Documents\DotaDB.mdf;Integrated Security=True;Connect Timeout=30");
        
        public UpdateDB(Form obj)
        {
            InitializeComponent();
            this.obj = obj;
            con.Open();
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Hero Name")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Hero Name";
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Team Name")
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Team Name";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            obj.Show();
            this.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {   
            openFileDialog1.Filter =  "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                selectedFile = openFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "Hero Name" && textBox1.Text != "")
            {
                UpdateDBLin ul = new UpdateDBLin();
                
                MessageBox.Show(ul.InsertHero(textBox1.Text));
            }
            else
            {
                MessageBox.Show("Enter Valid Name");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "Team Name" && textBox2.Text != "" && selectedFile!=null)
             {
                  UpdateDBLin ul = new UpdateDBLin();
                  MessageBox.Show(ul.InsertTeam(textBox2.Text, selectedFile));
                 
             }
             else
             {
                 MessageBox.Show("Enter Valid Info");
             }

        }
    }
}
