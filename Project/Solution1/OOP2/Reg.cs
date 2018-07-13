using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2
{
    public partial class Reg : Form
    {
        Form1 frm1;
        UpdateDBLin ul = new UpdateDBLin();
        Userinfo ui = new Userinfo();
        int flag=0;
        public Reg(Form1 parent)
        {
            InitializeComponent();
            frm1=parent;
            
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter Your Username")
            {
                textBox2.Text = "";
            }
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {

            frm1.Visible = true;
            Close();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "Enter Password")
            {
                textBox3.Text = "";
            }
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "Confirm Password")
            {
                textBox4.Text = "";
            }
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "Enter Email Address")
            {
                textBox5.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter Your Username";
            }
            ui=ul.getUser(textBox2.Text);

            if (textBox2.Text == "Enter Your Username")
            {
                label1.Visible = true;
                label1.Text = "Enter Valid Username";
                flag = 1;
                pictureBox1.BackgroundImage = Image.FromFile(@"F:\Important Documents\Project\Red_x.png");
            }
            else if (ui.UName != null )
            {
                label1.Visible = true;
                label1.Text = "Username In Use";
                flag = 1;
                pictureBox1.BackgroundImage = Image.FromFile(@"F:\Important Documents\Project\Red_x.png");
            }
            else
            {
                flag = 0;
                label1.Visible = false;
                pictureBox1.BackgroundImage = Image.FromFile(@"F:\Important Documents\Project\check.png");
            }

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Enter Password";
            }
            else
            {
                pictureBox2.BackgroundImage = Image.FromFile(@"F:\Important Documents\Project\check.png");
            }

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Confirm Password";
            }

            if (textBox3.Text == textBox4.Text)
            {
                pictureBox3.BackgroundImage = Image.FromFile(@"F:\Important Documents\Project\check.png");
            }
            else
            {
                pictureBox3.BackgroundImage = Image.FromFile(@"F:\Important Documents\Project\Red_x.png");
            }

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Enter Email Address";
            }

            if (textBox5.Text.Contains("@"))
            {
                pictureBox4.BackgroundImage = Image.FromFile(@"F:\Important Documents\Project\check.png");
            }
            else
            {
                pictureBox4.BackgroundImage = Image.FromFile(@"F:\Important Documents\Project\Red_x.png");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == textBox4.Text)
            {
                if (flag == 0)
                {
                    if (!textBox5.Text.Contains("@"))
                    {
                        MessageBox.Show("Email Formate Not Correct");
                    }
                    else
                    {

                        ui.UName = textBox2.Text;
                        ui.Pword = textBox3.Text;
                        ui.Igc = 10000;
                        ui.Em = textBox5.Text;
                       

                        ul.InsertUser(ui);
                        MessageBox.Show("Successfull");

                        frm1.Visible = true;
                        this.Close();

                    }
                }
                else
                {
                    MessageBox.Show("Username In Use");
                }

                
                
            }
            else
            {
                MessageBox.Show("Passwords Didnt Match");
            }
        }
    }
}
