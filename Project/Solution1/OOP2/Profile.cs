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
    public partial class Profile : Form
    {
        Form f;
        Userinfo ui;
        string selectedFile;

        public Profile(Form n,Userinfo ui)
        {
            InitializeComponent();
            this.f = n;
            this.ui = ui;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            richTextBox1.Visible = true;
            richTextBox1.Text = ui.Abouts;
            label8.Visible = false;
            button2.Visible = true;
            button4.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = false;
            label8.Visible = true;
            button2.Visible = false;
            button4.Visible = false;
            label8.Text = richTextBox1.Text;
            ui.Abouts = label8.Text;

            UpdateDBLin ul = new UpdateDBLin();
            if (selectedFile != null)
            {
                ul.UpdateU(ui.UName, richTextBox1.Text, selectedFile);
                pictureBox1.Image = Image.FromFile(selectedFile);
            }
            else
            {
                ul.UpdateU(ui.UName, richTextBox1.Text);
            }

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            f.Show();
            this.Close();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomeUser h = new HomeUser(ui);
            h.Show();
            this.Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeP cp = new ChangeP(this,ui);
            cp.Show();
            this.Hide();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {   
            openFileDialog1.Filter =  "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                selectedFile = openFileDialog1.FileName;
                ui.Picpath = selectedFile;
            }
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            label5.Text = ui.UName;
            label6.Text = ui.UID.ToString();
            label7.Text = ui.Igc.ToString();
            label8.Text = ui.Abouts;
            if (ui.Picpath != null)
            {
                pictureBox1.Image = Image.FromFile(ui.Picpath);
                
            }
        }

    }
}
