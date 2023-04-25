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
    public partial class ProfileAdmin : Form
    {
        long reg;
        public ProfileAdmin(long regno)
        {
            InitializeComponent();
            reg = regno;
        }

        private void messchangeicon_Click(object sender, EventArgs e)
        {
            MessAdmin frm = new MessAdmin(reg);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void ProfileAdmin_Load(object sender, EventArgs e)
        {

        }

        private void roomchangeicon_Click(object sender, EventArgs e)
        {
            ChangeAdmin frm = new ChangeAdmin(reg);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Stats frm = new Stats(reg);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }
    }
}
