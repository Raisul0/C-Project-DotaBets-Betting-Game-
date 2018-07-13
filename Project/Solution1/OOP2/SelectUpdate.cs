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
    public partial class SelectUpdate : Form
    {
        Form obj;
        public SelectUpdate(Form obj)
        {
            InitializeComponent();
            this.obj = obj;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            UpdateDB ui = new UpdateDB(this);
            ui.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            UpdateDel ud = new UpdateDel(this);
            ud.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            obj.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            UpdateCh uc = new UpdateCh(this);
            uc.Show();
            this.Hide();
        }
    }
}
