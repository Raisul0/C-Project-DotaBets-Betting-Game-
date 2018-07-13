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
    public partial class PredictionHistory : Form
    {
        Form obj;
        Userinfo ui;
        MyDBDataContext cntx;
        int data=0;
        public PredictionHistory(Form obj,Userinfo ui)
        {
           
            cntx = new MyDBDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=F:\Important Documents\Project\Solution1\OOP2\DotaDB.mdf;Integrated Security=True;Connect Timeout=30");

            InitializeComponent();
            this.obj = obj;
            this.ui = ui;
        }

        private void PredictionHistory_Load(object sender, EventArgs e)
        {
            
            var str = from a in cntx.UserPredictions
                      where a.Username == ui.UName
                      select a;

            dataGridView1.DataSource = str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            obj.Show();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.DataSource = null;
            int row = e.RowIndex;
            try
            {
                data = (int)dataGridView1[0, row].Value;

                var str = from a in cntx.MResults
                          where a.MatchId == data
                          select a;

                dataGridView2.DataSource = str;
            }
            catch
            {
                MessageBox.Show("Select A Proper Data Cell");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateDBLin ul = new UpdateDBLin();
            if (data == 0)
            {
                MessageBox.Show("Select A Cell");
            }
            else
            {
                ul.DeleteUserPrediction(ui.UName, data);
                MessageBox.Show("Successfull");
            }
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            PredictionHistory_Load(this, null);
        }
    }
}
