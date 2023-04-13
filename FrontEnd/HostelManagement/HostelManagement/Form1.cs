using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Oracle.ManagedDataAccess.Client;
//using Oracle.DataAccess.Client;
//using Oracle.DataAccess.Types;

namespace HostelManagement
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
            passTB.PasswordChar = '*';  
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (regTB.Text == string.Empty)
            {
                reqreg.Visible = true;
            }
            else
            {
                reqreg.Visible = false;
            }
            if (passTB.Text == string.Empty)
            {
                reqpass.Visible = true;
            }
            else
            {
                reqpass.Visible = false;
            }
            if (captcha.Checked == false)
            {
                reqcaptcha.Visible = true;
            }
            else
            {
                reqcaptcha.Visible = false; 
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 fr = new Form3();
            fr.Show();
            this.Hide();
        }
    }
}
