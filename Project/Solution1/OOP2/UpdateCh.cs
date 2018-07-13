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
    public partial class UpdateCh : Form
    {
        Form obj;
        
        public UpdateCh(Form obj)
        {
            InitializeComponent();
            this.obj = obj;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            obj.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateDBLin ul = new UpdateDBLin();
            string x = ul.UpdateHero(textBox1.Text, textBox2.Text);
            MessageBox.Show(x);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateDBLin ul = new UpdateDBLin();
            string x = ul.UpdateTeam(textBox3.Text, textBox4.Text);
            MessageBox.Show(x);
        }
    }
}
