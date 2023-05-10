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
    public partial class MessAdmin : Form
    {
        string reg;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        string name;
        public MessAdmin(string regno)
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
                comm.CommandText = "select * from administrator where admin_id = '" + reg.ToString() + "'";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "administrator");
                dt = ds.Tables["administrator"];
                dr = dt.Rows[i];
                namelabel.Text = dr["name"].ToString();
                name = namelabel.Text;
                comm.CommandText = "select * from mess_change";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "mess_change");
                dt = ds.Tables["mess_change"];
                int n = dt.Rows.Count;
                if (n == 0)
                {
                    requestLB.Text = "No new mess change applicatons...";
                }
                for (int j = 0; j < n; j++)
                {
                    dr = dt.Rows[j];
                    string student_reg = dr["reg_no"].ToString();
                    string oldname = dr["old_mess"].ToString();
                    string newname = dr["new_mess"].ToString();
                    requestLB.Items.Add("       "+student_reg+"  \t "+oldname+"\t   "+newname);
                }
                conn.Close();

            }
            catch (Exception e1)
            {
            }
        }

        private void MessAdmin_Load(object sender, EventArgs e)
        {

        }

        private void profileicon_Click(object sender, EventArgs e)
        {
            ProfileAdmin frm = new ProfileAdmin(reg);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void messchangeicon_Click(object sender, EventArgs e)
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

        private void RequestCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void apply_Click(object sender, EventArgs e)
        {
            if (requestLB.SelectedIndex <= -1)
            {
                approve.Visible = true;
            }
            else
            {
                approve.Visible = false;
            }
            if(!approve.Visible){
                MessageBox.Show("Approved mess change request!", "Successfully Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string ConStr = "DATA SOURCE=DESKTOP-FE4CR37:1521/XE;USER ID=SYSTEM;Password=rampage";
                OracleConnection conn = new OracleConnection(ConStr);
                conn.Open();
                OracleCommand comm = new OracleCommand("", conn);
                OracleTransaction txn = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    comm.CommandText = "select * from mess_change where reg_no = '" + requestLB.SelectedItem.ToString().Substring(7, 8) + "'";
                    comm.CommandType = CommandType.Text;
                    ds = new DataSet();
                    da = new OracleDataAdapter(comm.CommandText, conn);
                    da.Fill(ds, "mess_change");
                    dt = ds.Tables["mess_change"];
                    dr = dt.Rows[0];
                    string new_name = dr["new_mess"].ToString();
                    comm.CommandText = "select * from mess where mess_name = '" + new_name + "'";
                    comm.CommandType = CommandType.Text;
                    ds = new DataSet();
                    da = new OracleDataAdapter(comm.CommandText, conn);
                    da.Fill(ds, "mess");
                    dt = ds.Tables["mess"];
                    dr = dt.Rows[0];
                    string new_id = dr["mess_id"].ToString();
                    comm.CommandText = "update student set mess_id='"+new_id+"' where registration_number='" + requestLB.SelectedItem.ToString().Substring(7, 8) + "'";
                    comm.CommandType = CommandType.Text;
                    comm.ExecuteNonQuery();
                    comm.CommandText = "delete from mess_change where reg_no='" + requestLB.SelectedItem.ToString().Substring(7, 8) + "'";
                    comm.CommandType = CommandType.Text;
                    comm.ExecuteNonQuery();
                    txn.Commit();
                    requestLB.Items.RemoveAt(requestLB.SelectedIndex);
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