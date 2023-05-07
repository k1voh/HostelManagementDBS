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
    public partial class Change : Form
    {
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        long reg;
        string gender = string.Empty;
        string cg = string.Empty;
        string branch = string.Empty;
        string sem = string.Empty;
        string hostel;
        public Change(long rego)
        {
            InitializeComponent();
            reg = rego;
            try
            {
                string ConStr = "DATA SOURCE=DESKTOP-FE4CR37:1521/XE;USER ID=SYSTEM;Password=rampage";
                OracleConnection conn = new OracleConnection(ConStr);
                conn.Open();
                OracleCommand comm = new OracleCommand("", conn);
                comm.CommandText = "select * from student where registration_number = '" + reg.ToString()+"'";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "student");
                dt = ds.Tables["student"];
                dr = dt.Rows[i];
                int t = dt.Rows.Count;
                gender = dr["gender"].ToString();
                cg = dr["cgpa"].ToString();
                branch = dr["branch"].ToString();
                sem = dr["semester"].ToString();
                hostel= dr["hostel_id"].ToString();
                conn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
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
            string ConStr = "DATA SOURCE=DESKTOP-FE4CR37:1521/XE;USER ID=SYSTEM;Password=rampage";
            OracleConnection conn = new OracleConnection(ConStr);
            conn.Open();
            OracleCommand comm = new OracleCommand("", conn);
            OracleTransaction txn = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                comm.CommandText = "select * from mess_change where reg_no='" + reg.ToString() + "'";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "mess_change");
                dt = ds.Tables["mess_change"];
                int n = dt.Rows.Count;
                if (n == 0)
                {
                    Mess frm = new Mess(reg);
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mess change application under approval process\n\nPlease contact your administrator for updates!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception e1)
            {
                txn.Rollback();
                DialogResult dr = MessageBox.Show(e1.ToString(), "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)
                {
                    EditDetails frm1 = new EditDetails(reg);
                    this.Hide();
                    frm1.ShowDialog();
                    this.Close();
                }
            }
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
            if (cg == string.Empty || sem == string.Empty || branch == string.Empty || gender == string.Empty)
            {
                DialogResult dr = MessageBox.Show("Details not updated yet!\n\nUpdate details first to proceed for room booking", "Edit Details First", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    EditDetails frm = new EditDetails(reg);
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
            }
            else if (hostel.Length != 0)
            {
                MessageBox.Show("Already booked a room!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                Booking frm = new Booking(reg);
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
        }
    }
}
