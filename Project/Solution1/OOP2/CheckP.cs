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
    public partial class CheckP : Form
    {
        Form obj;
        Userinfo ui;
        public CheckP(Form obj,Userinfo ui)
        {
            InitializeComponent();
            this.obj=obj;
            this.ui = ui;
        }

        private void CheckP_Load(object sender, EventArgs e)
        {
            int mc;
            UpdateDBLin ul = new UpdateDBLin();
            mc=ul.getPreCount(ui.UName);

            
            List<int> li = ul.getPredID(ui.UName);


            if (mc == 0)
            {
                label3.Visible=true;
            }

            Panel[] x = new Panel[mc];
            int range = 3;

            for (int i = 0; i < mc; i++)
            {
                x[i] = new Panel();
                x[i].Name = "Panel" + i;
                x[i].Size = new Size(313, 87);
                x[i].Location = new Point(3, range);
                range += 93;
                x[i].Visible = true;
                x[i].BackgroundImage = Image.FromFile(@"F:\Important Documents\Project\dota.jpg");
                x[i].BackgroundImageLayout = ImageLayout.Stretch;

                panel1.Controls.Add(x[i]);

                Label[] l = new Label[2];
                PictureBox[] p = new PictureBox[3];
                Button b = new Button();


                b.Text = "Results";
                b.Location = new Point(119, 59);
                b.Visible = true;
                b.Size = new Size(75, 23);
                b.Click+= new EventHandler(button_Click);
                b.Name = li.ElementAt(i).ToString();
                x[i].Controls.Add(b);

                string[] t = ul.getPredTeam(li.ElementAt(i));
                
                
                for (int j = 0; j <= 1;j++ )
                {
                    l[j] = new Label();
                    l[j].Visible = true;
                    l[j].Name = "Label" + j;
                    l[j].Size = new Size(60, 40);
                    l[j].Text = t[j];
                    l[j].TextAlign = ContentAlignment.MiddleCenter;
                    x[i].Controls.Add(l[j]);



                    p[j] = new PictureBox();
                    p[j].Visible = true;
                    p[j].BackgroundImage = Image.FromFile(@ul.getIconPath(t[j]));
                    p[j].BackgroundImageLayout = ImageLayout.Zoom;
                    p[j].Size = new Size(45, 42);
                    x[i].Controls.Add(p[j]);
                    
                }

                l[0].Location = new Point(53, 11);
                l[1].Location = new Point(190, 11);
                p[0].Location = new Point(3, 11);
                p[1].Location = new Point(265, 11);
                p[2] = new PictureBox();
                p[2].Size = new Size(45, 42);
                p[2].Visible = true;
                p[2].Location = new Point(128, 11);
                p[2].BackgroundImage = Image.FromFile(@"F:\Important Documents\Project\Vs2.png");
                p[2].BackgroundImageLayout = ImageLayout.Zoom;
                x[i].Controls.Add(p[2]);
                
                

                
                
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            HomeUser hu = new HomeUser(ui);
            hu.Show();
        }

        private void button_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            UpdateDBLin ul = new UpdateDBLin();
            int bx=ui.Igc;
            int mid = Convert.ToInt32(button.Name);

            int flag = 0,w1=0,w2=0,w3=0;

            if (DateTime.Now >= ul.getMatchTime(Convert.ToInt32(button.Name)))
            {
                MResult mr = ul.getResult(Convert.ToInt32(button.Name));
                MatchP mp = ul.getMatchPred(Convert.ToInt32(button.Name),ui.UName);
                Bet b = ul.getBets(Convert.ToInt32(button.Name), ui.UName);

                
                if (mr.Win == mp.Win)
                {
                    ui.Igc +=Convert.ToInt32((b.Section1 * 2));
                    w1=Convert.ToInt32((b.Section1 * 2));
                    flag = 1;
                }

                if (mr.DireScore == mp.DireScore)
                {
                    ui.Igc +=Convert.ToInt32((b.Section3 * 3));
                    w3+=Convert.ToInt32((b.Section3 * 3));
                    flag = 1;
                }

                if (mr.RadientScore == mp.RadientScore)
                {
                    ui.Igc += Convert.ToInt32((b.Section3 * 3));
                    w3+=Convert.ToInt32((b.Section3 * 3));
                    flag = 1;
                }

                

                if (ul.HeroMatchRad(mp.Hero1,mid))
                {
                    ui.Igc += Convert.ToInt32((b.Section2 * 1));
                    w2+=Convert.ToInt32((b.Section2 * 1));
                    flag = 1;
                }
                if (ul.HeroMatchRad(mp.Hero2,mid))
                {
                    ui.Igc += Convert.ToInt32((b.Section2 * 1));
                        w2+=Convert.ToInt32((b.Section2 * 1));
                    flag = 1;
                }
                if (ul.HeroMatchRad(mp.Hero3,mid))
                {
                    ui.Igc += Convert.ToInt32((b.Section2 * 1));
                    w2+=Convert.ToInt32((b.Section2 * 1));
                    flag = 1;
                }
                if (ul.HeroMatchRad(mp.Hero4,mid))
                {
                    ui.Igc += Convert.ToInt32((b.Section2 * 1));
                    w2+=Convert.ToInt32((b.Section2 * 1));
                    flag = 1;
                }
                if (ul.HeroMatchRad(mp.Hero5,mid))
                {
                    ui.Igc += Convert.ToInt32((b.Section2 * 1));
                    w2+=Convert.ToInt32((b.Section2 * 1));
                    flag = 1;
                }
                if (ul.HeroMatchDir(mp.Hero6,mid))
                {
                    ui.Igc += Convert.ToInt32((b.Section3 * 1));
                    w2+=Convert.ToInt32((b.Section2 * 1));
                    flag = 1;
                }
                if (ul.HeroMatchDir(mp.Hero7,mid))
                {
                    ui.Igc += Convert.ToInt32((b.Section3 * 1));
                    w2+=Convert.ToInt32((b.Section2 * 1));
                    flag = 1;
                }
                if (ul.HeroMatchDir(mp.Hero8,mid))
                {
                    ui.Igc += Convert.ToInt32((b.Section3 * 1));
                    w2+=Convert.ToInt32((b.Section2 * 1));
                    flag = 1;
                }
                if (ul.HeroMatchDir(mp.Hero9,mid))
                {
                    ui.Igc += Convert.ToInt32((b.Section3 * 1));
                    w2+=Convert.ToInt32((b.Section2 * 1));
                    flag = 1;
                }
                if (ul.HeroMatchDir(mp.Hero10,mid))
                {
                    ui.Igc += Convert.ToInt32((b.Section3 * 1));
                    w2+=Convert.ToInt32((b.Section2 * 1));
                    flag = 1;
                }


                ul.UpdateIGC(ui.UName,ui.Igc);
                

                if (flag == 1)
                {
                    MessageBox.Show("Congrats ! You won.Your In Game Credit Has Been Updated");
                }
                else
                {
                    MessageBox.Show("Sorry ! You Didn't Win.Better Luck Next Time");
                }
                MatchResult mat = new MatchResult(obj, ui, mr, mp,w1,w2,w3, Convert.ToInt32(b.Section1), Convert.ToInt32(b.Section2), Convert.ToInt32(b.Section3),bx);
                this.Close();
                mat.Show();

            }
            else
            {
                MessageBox.Show("Results not Ready");
            }
            
            
        }
    }
}
