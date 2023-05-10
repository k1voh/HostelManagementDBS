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
    public partial class Mail : Form
    {
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        long reg = 0;
        public Mail(long regno)
        {
            InitializeComponent();
            mailLB.ScrollAlwaysVisible = true;
            reg = regno;
            reglabel.Text = reg.ToString();
            string ConStr = "DATA SOURCE=DESKTOP-FE4CR37:1521/XE;USER ID=SYSTEM;Password=rampage";
            OracleConnection conn = new OracleConnection(ConStr);
            try
            {
                conn.Open();
                OracleCommand comm = new OracleCommand("", conn);
                comm.CommandText = "select * from student where registration_number = '" + reg.ToString() + "'";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "student");
                dt = ds.Tables["student"];
                dr = dt.Rows[i];
                namelabel.Text = dr["name"].ToString();
                comm.CommandText = "select * from usertype where reg_no = '" + reg.ToString() + "'";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "usertype");
                dt = ds.Tables["usertype"];
                dr = dt.Rows[i];
                phonelabel.Text = dr["phone"].ToString();
                mailabel.Text = dr["email"].ToString();
                comm.CommandText = "select * from mail where reg_no ='"+reg.ToString()+"'";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "mail");
                dt = ds.Tables["mail"];
                int n = dt.Rows.Count;
                if (n == 0)
                {
                    mailLB.Items.Add("\t\t\tNo new mails...");
                }
                for (int j = 0; j < n; j++)
                {
                    dr = dt.Rows[j];
                    string id = dr["mail_code"].ToString();
                    string sub = dr["subject"].ToString();
                    string status = dr["status"].ToString();
                    mailLB.Items.Add(""+id + "  \t" + sub + "\t\t" + status);
                }
                conn.Close();

            }
            catch (Exception e1)
            {
            }
        }

        private void Mail_Load(object sender, EventArgs e)
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
            Booking frm = new Booking(reg);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void messchangeicon_Click(object sender, EventArgs e)
        {
            Mess frm = new Mess(reg);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void roomchangeicon_Click(object sender, EventArgs e)
        {
            Change frm = new Change(reg);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void issuesicon_Click(object sender, EventArgs e)
        {
            Issues frm = new Issues(reg);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to logout?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                LOGIN frm = new LOGIN();
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            if (mailLB.SelectedIndex <= -1)
            {
                reqmail.Visible = true;
            }
            else
            {
                reqmail.Visible = false;
            }
            if (!reqmail.Visible)
            {
                string ConStr = "DATA SOURCE=DESKTOP-FE4CR37:1521/XE;USER ID=SYSTEM;Password=rampage";
                OracleConnection conn = new OracleConnection(ConStr);
                conn.Open();
                OracleCommand comm = new OracleCommand("", conn);
                OracleTransaction txn = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    comm.CommandText = "delete from mail where mail_code='" + mailLB.SelectedItem.ToString().Substring(0,5) + "'";
                    comm.CommandType = CommandType.Text;
                    comm.ExecuteNonQuery();
                    txn.Commit();
                    mailLB.Items.RemoveAt(mailLB.SelectedIndex);
                }
                catch (Exception e1)
                {
                    txn.Rollback();
                    MessageBox.Show(e1.ToString(), "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
