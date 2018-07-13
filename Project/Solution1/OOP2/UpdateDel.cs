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
    public partial class UpdateDel : Form
    {
        Form obj;
        public UpdateDel(Form obj)
        {
            InitializeComponent();
            this.obj = obj;
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

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateDBLin ul = new UpdateDBLin();
            string x=ul.DeleteTeam(textBox2.Text);
            MessageBox.Show(x);
        }

        
    }
}
