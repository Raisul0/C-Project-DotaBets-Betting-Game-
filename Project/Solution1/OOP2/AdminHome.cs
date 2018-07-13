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
    public partial class AdminHome : Form
    {
        AdminInfo ai;

        public AdminHome(AdminInfo ai)
        {
            InitializeComponent();
            this.ai = ai;
            
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }


        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminHome h = new AdminHome(ai);
            h.Show();
            this.Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeP cp = new ChangeP(this,ai);
            cp.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            SelectUpdate su = new SelectUpdate(this);
            su.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            SetupM sm = new SetupM(this);
            sm.Show();
            this.Hide();
        }

        private void addAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAdmin a = new AddAdmin(this,ai);
            a.Show();
            this.Hide();
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {

            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            UpdateDBLin ul = new UpdateDBLin();

            List<string> li = ul.getAllUser();

            for (int i = 0; i < li.Count(); i++)
            {
                coll.Add(li.ElementAt(i).ToString());
            }

            textBox1.AutoCompleteCustomSource = coll;
        }

        private void buttom1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != "Username")
            {

                UpdateDBLin ul = new UpdateDBLin();
                User ui= ul.AdminGetUser(textBox1.Text);

                if (ui.UserName != null)
                {
                    AdminCUser ac = new AdminCUser(this, ui, ai);
                    this.Hide();
                    ac.Show();
                }
                else
                {
                    MessageBox.Show("User Not Found");
                }
            }
            else
            {
                MessageBox.Show("Enter Valid Username");
            }

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.Text = "";
                
            }
        
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Username";

            }
        }


    }
}
