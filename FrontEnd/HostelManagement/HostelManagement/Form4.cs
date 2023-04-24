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
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Profile page to be highlighted
        }

        private void roombookicon_Click(object sender, EventArgs e)
        {
            Booking frm = new Booking();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void messchangeicon_Click(object sender, EventArgs e)
        {
            Mess frm = new Mess();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void roomchangeicon_Click(object sender, EventArgs e)
        {
            Change frm = new Change();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void issuesicon_Click(object sender, EventArgs e)
        {
            Issues frm = new Issues();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

    }
}
