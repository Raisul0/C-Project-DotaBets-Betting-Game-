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
    public partial class MatchResult : Form
    {
        Form obj;
        Userinfo ui;
        MatchP mp;
        MResult mr;
        int bs1, bs2, bs3, w1, w2, w3;
        public MatchResult(Form obj,Userinfo ui,MResult mr,MatchP mp,int w1,int w2,int w3,int bs1,int bs2,int bs3,int bx)
        {
            InitializeComponent();
            this.obj = obj;
            this.ui = ui;
            this.mp = mp;
            this.mr = mr;
            this.bs1 = bs1;
            this.bs2 = bs2;
            this.bs3 = bs3;
            this.w1 = w1;
            this.w2 = w2;
            this.w3 = w3;
            textBox1.Text = bs1.ToString();
            textBox2.Text = bs2.ToString();
            textBox3.Text = bs3.ToString();
            textBox4.Text = w1.ToString();
            textBox5.Text = w2.ToString();
            textBox6.Text = w3.ToString();
            textBox7.Text = bx.ToString();
            textBox8.Text = ui.Igc.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
            HomeUser hu = new HomeUser(ui);
            hu.Show();
        }

        private void MatchResult_Load(object sender, EventArgs e)
        {
            UpdateDBLin ul = new UpdateDBLin();
            MyDBDataContext cntx;
            cntx = new MyDBDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=F:\Important Documents\Project\Solution1\OOP2\DotaDB.mdf;Integrated Security=True;Connect Timeout=30");

            var str = from a in cntx.MResults
                      where a.MatchId == mr.MatchId
                      select a;

            dataGridView1.DataSource = str;

            var st = from a in cntx.MatchPs
                     where a.MatchId == mp.MatchId && a.Username == mp.Username
                     select a;

            dataGridView2.DataSource = st;

            ul.InsertUserPrediction(mp, bs1, bs2, bs3, w1, w2, w3);
            ul.DeletePred(mp.Username, mp.MatchId);
        }
    }
}
