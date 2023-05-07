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
    public partial class Issues : Form
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

        public Issues(long rego)
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
                cg = dr["cgpa"].ToString();
                sem = dr["semester"].ToString();
                gender = dr["gender"].ToString();
                branch = dr["branch"].ToString();
                hostel = dr["hostel_id"].ToString();
                conn.Close();
            }
            catch (Exception e1)
            {
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void profileicon_Click(object sender, EventArgs e)
        {
            Profile frm = new Profile(reg);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void roombookicon_Click(object sender, EventArgs e)
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
            else if(hostel.Length!=0){
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

        private void messchangeicon_Click(object sender, EventArgs e)
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
        
        private void roomchangeicon_Click(object sender, EventArgs e)
        {
            Change frm = new Change(reg);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }
    }
}