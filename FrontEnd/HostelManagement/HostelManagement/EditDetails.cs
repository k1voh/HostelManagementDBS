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
    public partial class EditDetails : Form
    {
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        long reg;
        public EditDetails(long rego)
        {
            InitializeComponent();
            reg = rego;
            reglabel.Text = reg.ToString();
            try
            {
                string ConStr = "DATA SOURCE=DESKTOP-FE4CR37:1521/XE;USER ID=SYSTEM;Password=rampage";
                OracleConnection conn = new OracleConnection(ConStr);
                conn.Open();
                OracleCommand comm = new OracleCommand("", conn);
                comm.CommandText = "select * from usertype where reg_no = " + reg.ToString();
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "usertype");
                dt = ds.Tables["usertype"];
                dr = dt.Rows[i];
                phoneTB.Text = dr["phone"].ToString();
                mailTB.Text = dr["email"].ToString();
                comm.CommandText = "select * from student where registration_number = " + reg.ToString();
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "student");
                dt = ds.Tables["student"];
                dr = dt.Rows[i];
                namelabel.Text = dr["name"].ToString();
                cgpaTB.Text = dr["cgpa"].ToString();
                branchTB.Text = dr["branch"].ToString();
                conn.Close();

            }
            catch (Exception e1)
            {
            }
        }

        private void gender_Load(object sender, EventArgs e)
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

        private void savebutton_Click(object sender, EventArgs e)
        {
            string ConStr = "DATA SOURCE=DESKTOP-FE4CR37:1521/XE;USER ID=SYSTEM;Password=rampage";
            OracleConnection con = new OracleConnection(ConStr);
            if (!mailTB.Text.Contains("@gmail.com") && !mailTB.Text.Contains("@yahoo.com") && !mailTB.Text.Contains("@outlook.com") && !mailTB.Text.Contains("@hotmail.com") && !mailTB.Text.Contains("@icloud.com"))
            {
                invalidmail.Visible = true;
            }
            else {
                invalidmail.Visible = false;
            }
            if (phoneTB.Text.Length != 10)
            {
                invalidphone.Visible = true;
            }
            else
            {
                invalidphone.Visible = false;
            }
            if (branchTB.Text == string.Empty)
            {
                invalidbranch.Visible = true;
            }
            else {
                invalidbranch.Visible = false;
            }
            if (!invalidcg.Visible && !invalidmail.Visible && !invalidphone.Visible && !invalidbranch.Visible) {
                try
                {
                    con.Open();
                    OracleCommand cmd = new OracleCommand("", con);
                    OracleTransaction txn = con.BeginTransaction(IsolationLevel.ReadCommitted);
                    try
                    {
                        cmd.CommandText = "update usertype set phone='" + phoneTB.Text + "', email='" + mailTB.Text + "' where reg_no=" + reg.ToString();
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        //txn.Commit();
                        float cg = 0;
                        float.TryParse(cgpaTB.Text,out cg);
                        cmd.CommandText = "update student set cgpa=" + cg + ", branch='" + branchTB.Text + "',gender='"+ genderCB.SelectedItem.ToString()+"' where registration_number=" + reg.ToString();
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        txn.Commit();
                        Profile frm = new Profile(reg);
                        this.Hide();
                        frm.ShowDialog();
                        this.Close();
                    }
                    catch (Exception e1)
                    {
                        txn.Rollback();
                        DialogResult dr = MessageBox.Show(e1.ToString(), "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (dr == DialogResult.OK)
                        {
                            EditDetails frm = new EditDetails(reg);
                            this.Hide();
                            frm.ShowDialog();
                            this.Close();
                        }
                    }
                }
                catch (Exception e1)
                {
                    DialogResult dr = MessageBox.Show(e1.ToString(), "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dr == DialogResult.OK)
                    {
                        EditDetails frm = new EditDetails(reg);
                        this.Hide();
                        frm.ShowDialog();
                        this.Close();
                    }
                }
            }
        }

        private void forgotpassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 fr = new Form3();
            this.Hide();
            fr.ShowDialog();
            this.Close();
        }
    }
}
