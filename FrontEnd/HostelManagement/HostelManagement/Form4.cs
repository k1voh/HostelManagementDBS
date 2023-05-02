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
    public partial class Profile : Form
    {
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        long reg=0;
        public Profile(long regno)
        {
            InitializeComponent();
            reg = regno;
            reglabel.Text=reg.ToString();
            string ConStr = "DATA SOURCE=DESKTOP-FE4CR37:1521/XE;USER ID=SYSTEM;Password=rampage";
            OracleConnection conn = new OracleConnection(ConStr);

            try
            {
                conn.Open();
                OracleCommand comm = new OracleCommand("", conn);
                comm.CommandText = "select * from usertype where reg_no = "+reg.ToString();
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "usertype");
                dt = ds.Tables["usertype"];
                dr = dt.Rows[i];
                phonelabel.Text = dr["phone"].ToString();
                emailabel.Text = dr["email"].ToString();
                comm.CommandText = "select * from student where registration_number = "+reg.ToString();
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "student");
                dt = ds.Tables["student"];
                dr = dt.Rows[i];
                namelabel.Text = dr["name"].ToString();
                genderlabel.Text = dr["gender"].ToString();
                cgpalabel.Text = dr["cgpa"].ToString();
                branchlabel.Text = dr["branch"].ToString();
                semlabel.Text = dr["semester"].ToString();
                conn.Close();

            }
            catch (Exception e1)
            {
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void roombookicon_Click(object sender, EventArgs e)
        {
            if (cgpalabel.Text != string.Empty && branchlabel.Text != string.Empty && genderlabel.Text != string.Empty)
            {
                Booking frm = new Booking(reg);
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
            else
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
        }

        private void messchangeicon_Click(object sender, EventArgs e)
        {
            Mess frm = new Mess(reg);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void Profile_Load(object sender, EventArgs e)
        {

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

        private void editbutton_Click(object sender, EventArgs e)
        {
            EditDetails frm = new EditDetails(reg);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }
    }
}
