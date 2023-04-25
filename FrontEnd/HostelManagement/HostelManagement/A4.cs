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
    public partial class Stats : Form
    {
        long reg;
        public Stats(long regno)
        {
            InitializeComponent();
            reg = regno;
        }

        private void profileicon_Click(object sender, EventArgs e)
        {
            ProfileAdmin frm = new ProfileAdmin(reg);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void roomchangeicon_Click(object sender, EventArgs e)
        {
            ChangeAdmin frm = new ChangeAdmin(reg);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void messchangeicon_Click(object sender, EventArgs e)
        {
            MessAdmin frm = new MessAdmin(reg);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void Stats_Load(object sender, EventArgs e)
        {

        }
    }
}
