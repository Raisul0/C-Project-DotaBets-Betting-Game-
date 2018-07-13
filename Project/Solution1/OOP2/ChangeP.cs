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
    public partial class ChangeP : Form
    {
        Form obj;
        Userinfo ui = new Userinfo();
        AdminInfo ai = new AdminInfo();
        int check;
        public ChangeP(Form obj,Userinfo ui)
        {
            InitializeComponent();
            this.obj = obj;
            this.ui = ui;
            check = 0;
        }
        public ChangeP(Form obj,AdminInfo ai)
        {
            InitializeComponent();
            this.obj = obj;
            this.ai = ai;
            check = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {   obj.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateDBLin ul = new UpdateDBLin();
            string pass;
            if (check == 0)
            {
                pass = ul.getPassword(ui.UName);
                if (textBox1.Text == pass && textBox2.Text == textBox3.Text)
                {
                    ul.UpdateUP(ui.UName, textBox2.Text);

                    MessageBox.Show("Successfull");
                    obj.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password didn't match");
                }

            }
            else
            {
                pass = ul.getAdminPass(ai.UName);
                if (textBox1.Text == pass && textBox2.Text == textBox3.Text)
                {
                    ul.UpdateAP(ai.UName, textBox2.Text);
                    MessageBox.Show("Successfull");
                    obj.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password didn't match");
                }
            }
            
        }

       
    }
}
