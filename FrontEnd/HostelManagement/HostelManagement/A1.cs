using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace HostelManagement
{
    public partial class ProfileAdmin : Form
    {
        long reg;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        public ProfileAdmin(long regno)
        {
            InitializeComponent();
            reg = regno;
            reglabel.Text = reg.ToString();
            string ConStr = "DATA SOURCE=DESKTOP-FE4CR37:1521/XE;USER ID=SYSTEM;Password=rampage";
            OracleConnection conn = new OracleConnection(ConStr);

            try
            {
                conn.Open();
                OracleCommand comm = new OracleCommand("", conn);
                comm.CommandText = "select * from usertype where reg_no = " + reg.ToString();
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "usertype");
                dt = ds.Tables["usertype"];
                dr = dt.Rows[i];
                phonelabel.Text = dr["phone"].ToString();
                emailabel.Text = dr["email"].ToString();
                comm.CommandText = "select * from administrator where admin_id = " + reg.ToString();
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "administrator");
                dt = ds.Tables["administrator"];
                dr = dt.Rows[i];
                namelabel.Text = dr["name"].ToString();
                conn.Close();

            }
            catch (Exception e1)
            {
                //label1.Text = e1.ToString();
            }
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

        private void reglabel_Click(object sender, EventArgs e)
        {

        }
    }
}
