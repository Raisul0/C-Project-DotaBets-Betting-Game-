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
    public partial class Form1 : Form
    {
        Userinfo ui = new Userinfo();
        AdminInfo ai = new AdminInfo();
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "Enter Username";
            textBox2.Text = "Enter Password";
            
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Username")
            {
                textBox1.Text = "";
            }
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter Username";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter Password")
            {
                textBox2.Text = "";
            }
            
            
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter Password";
                
            }
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            Reg r = new Reg(this);
            r.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            UpdateDBLin ul = new UpdateDBLin();


            string pass;

            if (textBox1.Text.StartsWith("Admin") == true)
            {
                ai = ul.getAdmin(textBox1.Text);
                pass = ul.getAdminPass(textBox1.Text);

                if (textBox2.Text == pass)
                {
                    AdminHome h = new AdminHome(ai);
                    h.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Wrong Password or Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {   
                ui=ul.getUser(textBox1.Text);
                pass = ul.getPassword(textBox1.Text);

                if (textBox2.Text == pass)
                {
                    HomeUser h = new HomeUser(ui);
                    h.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Wrong Password or Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        

       
    }
}
