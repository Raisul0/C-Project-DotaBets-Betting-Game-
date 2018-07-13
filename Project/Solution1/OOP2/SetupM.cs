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
    public partial class SetupM : Form
    {
        Form obj;
        public SetupM(Form obj)
        {
            InitializeComponent();
            this.obj = obj;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            obj.Show();
            this.Close();
        }

        private void SetupM_Load(object sender, EventArgs e)
        {   
            UpdateDBLin ul= new UpdateDBLin();
            BindingSource bs1 = new BindingSource();
            bs1.DataSource =ul.getTeam();
            comboBox1.DataSource = bs1;
            BindingSource bs2 = new BindingSource();
            bs2.DataSource = ul.getTeam();
            comboBox2.DataSource = bs2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.ToString() == comboBox2.SelectedValue.ToString())
            {
                MessageBox.Show("Select Two Different Team");
            }
            else
            {
                UpdateDBLin ul = new UpdateDBLin();
                ul.InsertMatch(comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString(), dateTimePicker1.Value.Date + dateTimePicker2.Value.TimeOfDay);
                MessageBox.Show("Match Inserted");
            }
        }
    }
}
