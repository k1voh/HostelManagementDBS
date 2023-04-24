using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelManagement
{
    public partial class Change : Form
    {
        public Change()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void issuesicon_Click(object sender, EventArgs e)
        {
            Issues frm = new Issues();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void messchangeicon_Click_1(object sender, EventArgs e)
        {
            Mess frm = new Mess();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void profileicon_Click_1(object sender, EventArgs e)
        {
            Profile frm = new Profile();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void roombookicon_Click_1(object sender, EventArgs e)
        {
            Booking frm = new Booking();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }
    }
}
