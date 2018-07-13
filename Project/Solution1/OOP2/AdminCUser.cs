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
    public partial class AdminCUser : Form
    {
        Form obj;
        AdminInfo ai;
        
        User ui;
        UpdateDBLin ul = new UpdateDBLin();
        public AdminCUser(Form obj,User ui,AdminInfo ai)
        {
            this.obj = obj;
            this.ai = ai;
            this.ui = ui;

            InitializeComponent();
        }

        private void AdminCUser_Load(object sender, EventArgs e)
        {
            
            textBox1.Text = ui.UserName;
            textBox2.Text = ui.UserId.ToString();
            numericUpDown1.Value = ui.IGC;
            label5.Text = ui.AboutSelf;
            if (ui.Picture != null)
            {
                pictureBox1.BackgroundImage = Image.FromFile(@ui.Picture);
                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            }
            else
            {
                pictureBox1.BackgroundImage = Image.FromFile(@"F:\Important Documents\Project\user (1).png");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            obj.Show();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value!=ui.IGC)
            {
                ul.UpdateIGC(ui.UserName, Convert.ToInt32(numericUpDown1.Value));
                MessageBox.Show("Updated");
            }
        }
        
    }
}
