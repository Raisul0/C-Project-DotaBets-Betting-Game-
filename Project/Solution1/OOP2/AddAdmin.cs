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
    public partial class AddAdmin : Form
    {
        AdminInfo ai;
        Form obj;
        public AddAdmin(Form obj,AdminInfo ai)
        {
            this.obj = obj;
            this.ai = ai;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            obj.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.StartsWith("Admin"))
            {
                if (textBox3.Text == ai.Pword)
                {
                    UpdateDBLin ul = new UpdateDBLin();
                    ul.InsertAdmin(textBox1.Text, textBox2.Text);
                    MessageBox.Show("Admin Inserted");
                }
                else
                {
                    MessageBox.Show("Password Incorrect");
                }
            }
            else
            {
                MessageBox.Show("Admin Username Must Start with 'Admin'");
            }
        }
    }
}
