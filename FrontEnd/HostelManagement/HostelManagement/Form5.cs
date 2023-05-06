using System;
using System.Collections;
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
    public partial class Booking : Form
    {
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        Dictionary<string, double> d20 = new Dictionary<string, double>();
        Dictionary<string, double> d21 = new Dictionary<string, double>();
        Dictionary<int, int> hostel_mess = new Dictionary<int, int>();
        int i = 0;
        long reg;
        public Booking(long regno)
        {
            
            InitializeComponent();
            hostel_mess.Add(10, 1);
            hostel_mess.Add(11, 2);
            hostel_mess.Add(12, 3);
            hostel_mess.Add(20, 4);
            hostel_mess.Add(21, 5);
            reg = regno;
            reglabel.Text = reg.ToString();
            string ConStr = "DATA SOURCE=DESKTOP-FE4CR37:1521/XE;USER ID=SYSTEM;Password=rampage";
            OracleConnection conn = new OracleConnection(ConStr);
            try
            {
                conn.Open();
                OracleCommand comm = new OracleCommand("", conn);
                comm.CommandText = "select * from student where registration_number = '" + reg.ToString()+"'";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "student");
                dt = ds.Tables["student"];
                dr = dt.Rows[i];
                namelabel.Text = dr["name"].ToString();
                cgpalabel.Text = dr["cgpa"].ToString();
                genderlabel.Text = dr["gender"].ToString();
                if (genderlabel.Text == "MALE")
                {
                    MblockCB.Visible = true;
                    bookbuttonM.Visible = true;
                    malecriteria.Visible = true;
                }
                else 
                {
                    FblockCB.Visible = true;
                    bookuttonF.Visible = true;
                    femalecriteria.Visible = true;
                }
                conn.Close();

            }
            catch (Exception e1)
            {
            }
        }

        private void profileicon_Click(object sender, EventArgs e)
        {
            Profile frm = new Profile(reg);
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

        private void Booking_Load(object sender, EventArgs e)
        {

        }

        private void cgpalabel_Click(object sender, EventArgs e)
        {

        }

        private void bookbutton_Click(object sender, EventArgs e)
        {
            string ConStr = "DATA SOURCE=DESKTOP-FE4CR37:1521/XE;USER ID=SYSTEM;Password=rampage";
            OracleConnection conn = new OracleConnection(ConStr);
            try
            {
                if (genderlabel.Text == "MALE")
                {
                    conn.Open();
                    OracleCommand comm = new OracleCommand("", conn);
                    comm.CommandText = "select * from hostel_rooms where cgpa_needed <= '" + cgpalabel.Text + "' and room_id='"+ roomtypeCB.SelectedItem.ToString()+"' and hostel_id='"+ MblockCB.SelectedItem.ToString()+"'";
                    comm.CommandType = CommandType.Text;
                    ds = new DataSet();
                    da = new OracleDataAdapter(comm.CommandText, conn);
                    da.Fill(ds, "hostel_rooms");
                    dt = ds.Tables["hostel_rooms"];
                    int rcount = dt.Rows.Count;
                    if (rcount == 0)
                    {
                        MessageBox.Show("Not eligible for this room!\n\nCheck criteria before booking", "Booking Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                    {
                        DialogResult dr0 = MessageBox.Show("Are you sure you want to book this room?", "Booking confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr0 == DialogResult.Yes)
                        {
                            DialogResult dr1 = MessageBox.Show("You have successfully booked a room", "Booking confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (dr1== DialogResult.OK) {
                                 Profile frm = new Profile(reg);
                                    this.Hide();
                                    frm.ShowDialog();
                                    this.Close();
                                //UPDATE BLOCK TABLE
                                /*OracleCommand cmd = new OracleCommand("", conn);
                                OracleTransaction txn = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                                try
                                {
                                    comm.CommandText = "select min(room_number) from b" + MblockCB.SelectedItem.ToString() + " where room_id='" + roomtypeCB.SelectedItem.ToString() + "' and reg_no='NULL'";
                                    comm.CommandType = CommandType.Text;
                                    ds = new DataSet();
                                    da = new OracleDataAdapter(comm.CommandText, conn);
                                    da.Fill(ds, "b" + MblockCB.SelectedItem.ToString());
                                    dt = ds.Tables["b" + MblockCB.SelectedItem.ToString()];
                                    dr = dt.Rows[0];
                                    MessageBox.Show(dr["min(room_number)"].ToString());
                                    cmd.CommandText = "update b" + MblockCB.SelectedItem.ToString()+ " set regno='" + phoneTB.Text + "', email='" + mailTB.Text + "' where reg_no=" + reg.ToString();
                                    cmd.CommandType = CommandType.Text;
                                    cmd.ExecuteNonQuery();
                                    //txn.Commit();
                                    float cg = 0;
                                    float.TryParse(cgpaTB.Text, out cg);
                                    cmd.CommandText = "update student set  cgpa=" + cg + ", branch='" + branchTB.Text + "',gender='" + genderCB.SelectedItem.ToString() + "' where registration_number=" + reg.ToString();
                                    cmd.CommandType = CommandType.Text;
                                    cmd.ExecuteNonQuery();
                                    cmd.CommandText = "update student set semester=" + sem + " where registration_number=" + reg.ToString();
                                    cmd.CommandType = CommandType.Text;
                                    cmd.ExecuteNonQuery();
                                    txn.Commit();
                                     
                                   
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
                                }*/
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString(), "Not Found");
            }
        }

        private void bookuttonF_Click(object sender, EventArgs e)
        {
            d20.Add("01AC", 8.5);
            d20.Add("01NC", 7);
            d20.Add("02AC", 7);
            d20.Add("02NC", 6.5);
            d21.Add("01AC", 8);
            d21.Add("01NC", 8);
            d21.Add("02AC", 7.5);
            d21.Add("02NC", 7);
            string ConStr = "DATA SOURCE=DESKTOP-FE4CR37:1521/XE;USER ID=SYSTEM;Password=rampage";
            OracleConnection conn = new OracleConnection(ConStr);
                if (genderlabel.Text == "FEMALE")
                {
                    conn.Open();
                    OracleCommand comm = new OracleCommand("", conn);
                    int blockno;
                    int.TryParse(FblockCB.SelectedItem.ToString(),out blockno);
                    float cg;
                    float.TryParse(cgpalabel.Text, out cg);
                    comm.CommandText = "select * from hostel_rooms where cgpa_needed<='"+cgpalabel.Text+"' and room_id='"+roomtypeCB.SelectedItem.ToString()+"'";
                    comm.CommandType = CommandType.Text;
                    ds = new DataSet();
                    da = new OracleDataAdapter(comm.CommandText, conn);
                    da.Fill(ds, "hostel_rooms");
                    dt = ds.Tables["hostel_rooms"];
                    int rcount = dt.Rows.Count;
                    if (blockno == 20)
                    {
                        if (d20[roomtypeCB.SelectedItem.ToString()] <= cg)
                        {
                            DialogResult dr = MessageBox.Show("Are you sure you want to book this room?", "Booking confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dr == DialogResult.Yes)
                            {
                                DialogResult dr1 = MessageBox.Show("You have successfully booked a room", "Booking confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (dr1 == DialogResult.OK)
                                {
                                    Profile frm = new Profile(reg);
                                    this.Hide();
                                    frm.ShowDialog();
                                    this.Close();
                                }
                            }
                        }
                        else {
                            DialogResult dr = MessageBox.Show("Not eligible for this room!\n\nCheck criteria before booking", "Booking Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (dr == DialogResult.OK) {
                                Booking frm = new Booking(reg);
                                this.Hide();
                                frm.ShowDialog();
                                this.Close();
                            }
                        }
                    }
                    else if (blockno == 21)
                    {
                        if (d21[roomtypeCB.SelectedItem.ToString()] <= cg)
                        {
                            DialogResult dr = MessageBox.Show("Are you sure you want to book this room?", "Booking confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dr == DialogResult.Yes)
                            {
                                DialogResult dr1 = MessageBox.Show("You have successfully booked a room", "Booking confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (dr1 == DialogResult.OK)
                                {
                                    Profile frm = new Profile(reg);
                                    this.Hide();
                                    frm.ShowDialog();
                                    this.Close();
                                }
                            }
                        }
                        else
                        {
                            DialogResult dr = MessageBox.Show("Not eligible for this room!", "Booking Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (dr == DialogResult.OK)
                            {
                                Booking frm = new Booking(reg);
                                this.Hide();
                                frm.ShowDialog();
                                this.Close();
                            }
                        }
                    }
                    conn.Close();
                }
        }
    }
}

// For mess name, refer mess-id and hostel-id mapping