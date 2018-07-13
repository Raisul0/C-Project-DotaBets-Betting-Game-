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
    public partial class HomeUser : Form
    {
        int x;
        Userinfo ui;
        public HomeUser(Userinfo ui)
        {
            InitializeComponent();
            this.ui = ui;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
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
            Profile pf = new Profile(this,ui);
            pf.Show();
            this.Hide();
        }


        private void HomeUser_Load(object sender, EventArgs e)
        {
            UpdateDBLin ul = new UpdateDBLin();
            x = ul.MatchCount();

            if (x == 0)
            {
                label4.Visible = true;
            }
            List<string>[] li = ul.getMatch();
            List<DateTime> dt = ul.getTime();
            int range = 3;
            Panel[] p = new Panel[x];
            for (int i = 0; i < x; i++)
            {
                
                p[i] = new Panel();
                p[i].Name = "Panel" + i;
                p[i].BackgroundImage = Image.FromFile(@"F:\Important Documents\Project\Vs.jpg");
                p[i].BackgroundImageLayout = ImageLayout.Zoom;
                p[i].Visible = true;
                p[i].Location = new Point(3,range);
                range += 76;
                p[i].Size = new Size(345, 67);
                p[i].Cursor = Cursors.Hand;
                p[i].Click += new EventHandler(panelClick);

                PictureBox[] px = new PictureBox[2];
                Label[] lb = new Label[2];
                Label date = new Label();
                date.Location = new Point(225, 55);
                date.BackColor = Color.Transparent;
                date.Size = new Size(120, 12);
                date.TextAlign = ContentAlignment.MiddleCenter;
                date.Font = new Font("Times New Roman",7, FontStyle.Regular);
                date.Name = "Date";
                p[i].Controls.Add(date);
                for (int j = 0; j < 2; j++)
                {
                    px[j] = new PictureBox();
                    lb[j] = new Label();
                    px[j].Size = new Size(35, 35);
                    lb[j].Size = new Size(65, 15);

                    lb[j].Name = "Label" + j;
                    lb[j].TextAlign = ContentAlignment.MiddleCenter;
                    px[j].Visible = true;
                    p[i].Controls.Add(lb[j]);
                    p[i].Controls.Add(px[j]);
                    lb[j].Visible = true;
                    px[j].BackgroundImageLayout = ImageLayout.Zoom;
                }
                px[0].Location = new Point(22, 15);
                px[1].Location = new Point(290, 15);
                px[0].BackgroundImage = Image.FromFile(@ul.getIconPath(li[0].ElementAt(i)));
                px[1].BackgroundImage = Image.FromFile(@ul.getIconPath(li[1].ElementAt(i)));
                
                lb[0].Text = li[0].ElementAt(i);
                lb[1].Text = li[1].ElementAt(i);
                date.Text = dt.ElementAt(i).ToString();
                lb[0].Location = new Point(62, 24);
                lb[1].Location = new Point(219, 24);
                   
                panel4.Controls.Add(p[i]);

            }
            
            
        }
        
        void panelClick(object sender, EventArgs e)
        {   
            var panel = sender as Panel;
            string dire="";
            string radient="";
            DateTime date = DateTime.Now;
            foreach (Control p in panel.Controls)
            {
                if (p is Label)
                {
                    if (p.Name == "Label0")
                    {
                        radient = p.Text;
                    }
                    else if (p.Name == "Label1")
                    {
                        dire = p.Text;
                    }
                    else if (p.Name == "Date")
                    {
                        date = Convert.ToDateTime(p.Text);
                    }
                }
            }

                UserBet ub = new UserBet(this,radient,dire,date,ui);
                ub.Show();
                this.Visible = false;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            CheckP cp = new CheckP(this,ui);
            this.Close();
            cp.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            PredictionHistory ph = new PredictionHistory(this, ui);
            ph.Show();
            this.Hide();
        }
    }
}
