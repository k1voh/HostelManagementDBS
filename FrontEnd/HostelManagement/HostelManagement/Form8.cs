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
    public partial class Issues : Form
    {
        long regno;
        public Issues(long reg)
        {
            InitializeComponent();
            regno = reg;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void profileicon_Click(object sender, EventArgs e)
        {
            Profile frm = new Profile(regno);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void roombookicon_Click(object sender, EventArgs e)
        {
            Booking frm = new Booking(regno);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void messchangeicon_Click(object sender, EventArgs e)
        {
            Mess frm = new Mess(regno);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void roomchangeicon_Click(object sender, EventArgs e)
        {
            Change frm = new Change(regno);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }
    }
}