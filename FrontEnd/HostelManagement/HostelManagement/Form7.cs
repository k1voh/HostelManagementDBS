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
        long reg;
        public Change(long regno)
        {
            InitializeComponent();
            reg = regno;
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void issuesicon_Click(object sender, EventArgs e)
        {
            Issues frm = new Issues(reg);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void messchangeicon_Click_1(object sender, EventArgs e)
        {
            Mess frm = new Mess(reg);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void profileicon_Click_1(object sender, EventArgs e)
        {
            Profile frm = new Profile(reg);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void roombookicon_Click_1(object sender, EventArgs e)
        {
            Booking frm = new Booking(reg);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }
    }
}
