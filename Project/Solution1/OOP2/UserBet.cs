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
    public partial class UserBet : Form
    {
        Form obj;
        Userinfo ui;
        UpdateDBLin ul = new UpdateDBLin();
        int MatchID;
        string w;
        public UserBet(Form obj,string x,string y,DateTime d,Userinfo ui)
        {
            InitializeComponent();
            this.obj = obj;
            radioButton1.Text = x;
            radioButton2.Text = y;
            this.ui = ui;
            this.MatchID = ul.getMatchID(x, y, d);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profile p = new Profile(this,ui);
            p.Show();
            this.Hide();
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


        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
            HomeUser hu = new HomeUser(ui);
            hu.Show();
        }

        private void UserBet_Load(object sender, EventArgs e)
        {
            UpdateDBLin ul = new UpdateDBLin();
            BindingSource[] bs = new BindingSource[10];
            for (int i = 0; i < 10; i++)
            {
                bs[i] = new BindingSource();
                bs[i].DataSource = ul.getHero();
            }
            comboBox1.DataSource = bs[0];
            comboBox2.DataSource = bs[1];
            comboBox3.DataSource = bs[2];
            comboBox4.DataSource = bs[3];
            comboBox5.DataSource = bs[4];
            comboBox6.DataSource = bs[5];
            comboBox7.DataSource = bs[6];
            comboBox8.DataSource = bs[7];
            comboBox9.DataSource = bs[8];
            comboBox10.DataSource = bs[9];

            pictureBox13.BackgroundImage=pictureBox11.BackgroundImage = Image.FromFile(ul.getIconPath(radioButton1.Text));
            pictureBox14.BackgroundImage=pictureBox12.BackgroundImage = Image.FromFile(ul.getIconPath(radioButton2.Text));

            radioButton2.Size = new Size(90, 17);
            radioButton1.Size = new Size(90, 17);
            radioButton1.Location = new Point(52, 32);
            radioButton2.Location = new Point(190, 32);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int flag = 0;
            if (ul.detetcPred(ui.UName, MatchID))
            {
                MessageBox.Show("You Already Have a Pending Result");
            }
            else
            {


                if (Convert.ToInt32(numericUpDown2.Value) != 0)
                {
                    if (comboBox1.SelectedIndex == comboBox2.SelectedIndex || comboBox1.SelectedIndex == comboBox3.SelectedIndex || comboBox1.SelectedIndex == comboBox4.SelectedIndex || comboBox1.SelectedIndex == comboBox5.SelectedIndex)
                    {
                        flag = 1;
                    }
                    else if (comboBox2.SelectedIndex == comboBox3.SelectedIndex || comboBox2.SelectedIndex == comboBox4.SelectedIndex || comboBox2.SelectedIndex == comboBox5.SelectedIndex)
                    {
                        flag = 1;
                    }
                    else if (comboBox3.SelectedIndex == comboBox4.SelectedIndex || comboBox3.SelectedIndex == comboBox5.SelectedIndex)
                    {
                        flag = 1;
                    }
                    else if (comboBox4.SelectedIndex == comboBox5.SelectedIndex)
                    {
                        flag = 1;
                    }
                    else if (comboBox6.SelectedIndex == comboBox7.SelectedIndex || comboBox6.SelectedIndex == comboBox8.SelectedIndex || comboBox6.SelectedIndex == comboBox9.SelectedIndex || comboBox6.SelectedIndex == comboBox10.SelectedIndex)
                    {
                        flag = 1;
                    }
                    else if (comboBox7.SelectedIndex == comboBox8.SelectedIndex || comboBox7.SelectedIndex == comboBox9.SelectedIndex || comboBox7.SelectedIndex == comboBox10.SelectedIndex)
                    {
                        flag = 1;
                    }
                    else if (comboBox8.SelectedIndex == comboBox9.SelectedIndex || comboBox8.SelectedIndex == comboBox10.SelectedIndex)
                    {
                        flag = 1;
                    }
                    else if (comboBox9.SelectedIndex == comboBox10.SelectedIndex)
                    {
                        flag = 1;
                    }

                }
                else
                {
                    flag = 0;
                }

                if (flag == 0)
                {
                    int n1 = Convert.ToInt32(numericUpDown1.Value);
                    int n2 = Convert.ToInt32(numericUpDown2.Value);
                    int n3 = Convert.ToInt32(numericUpDown5.Value);

                    int r = Convert.ToInt32(numericUpDown3.Value);
                    int d = Convert.ToInt32(numericUpDown4.Value);

                    ul.InsertBet(ui.UName, MatchID, n1, n2, n3);
                    string[] h = new string[10];




                    h[0] = comboBox1.Text;
                    h[1] = comboBox2.Text;
                    h[2] = comboBox3.Text;
                    h[3] = comboBox4.Text;
                    h[4] = comboBox5.Text;
                    h[5] = comboBox6.Text;
                    h[6] = comboBox7.Text;
                    h[7] = comboBox8.Text;
                    h[8] = comboBox9.Text;
                    h[9] = comboBox10.Text;

                    if (radioButton1.Checked == true)
                    {
                        w = "Radient";
                    }
                    else if (radioButton2.Checked == true)
                    {
                        w = "Dire";
                    }

                    ul.InsertPrediction(ui.UName, MatchID, w, h, r, d);
                    MessageBox.Show("Your Prediction's are Submitted");
                    ui.Igc -= (n1 + n2 + n3);
                    ul.UpdateIGC(ui.UName, ui.Igc);

                    this.Close();
                    HomeUser hu = new HomeUser(ui);
                    hu.Show();
                }
                else
                {
                    MessageBox.Show("Cant Select Same Hero More than once For same Team");
                }
                    
                
            }

            
            
        }

        
    }
}
