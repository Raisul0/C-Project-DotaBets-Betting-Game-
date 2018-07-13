using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Reg : Form
    {
        
        public Reg()
        {
            InitializeComponent();
            
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
            
            
        }
    }
}
