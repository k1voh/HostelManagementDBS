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
    public partial class Stats : Form
    {
        string reg;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        public Stats(string regno)
        {
            InitializeComponent();
            reg = regno;
            //reglabel.Text = reg.ToString();
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
                //phonelabel.Text = dr["phone"].ToString();
                //emailabel.Text = dr["email"].ToString();
                comm.CommandText = "select * from student where registration_number = " + reg.ToString();
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "student");
                dt = ds.Tables["student"];
                dr = dt.Rows[i];
                //namelabel.Text = dr["name"].ToString();
                //genderlabel.Text = dr["gender"].ToString();
                //cgpalabel.Text = dr["cgpa"].ToString();
                //branchlabel.Text = dr["branch"].ToString();
                conn.Close();

            }
            catch (Exception e1)
            {
                //label1.Text = e1.ToString();
            }
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
