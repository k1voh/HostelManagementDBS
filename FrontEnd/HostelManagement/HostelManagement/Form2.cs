using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelManagement
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (regTB.Text == string.Empty)
            {
                reqreg.Visible = true;
            }
            else
            {
                reqreg.Visible = false;
            }
            if(userTB.Text == string.Empty)
            {
                requser.Visible = true;
            }
            else
            {
                requser.Visible= false;
            }
            if(contactTB.Text == string.Empty)
            {
                reqcontact.Visible = true;
            }
            else
            {
                reqcontact.Visible= false;
            }
            if(mailTB.Text == string.Empty)
            {
                reqmail.Visible = true;
            }
            else
            {
                reqmail.Visible= false;
            }
            if(passTB.Text == string.Empty)
            {
                reqpass.Visible = true;
            }
            else
            {
                reqpass.Visible = false;
            }
            if(retypepassTB.Text == string.Empty)
            {
                reqretype.Visible = true;
            }
            else
            {
                reqretype.Visible = false;
            }
            if(captcha.Checked == false)
            {
                reqcaptcha.Visible = true;
            }
            else
            {
                reqcaptcha.Visible= false;
            }
            if(!reqcaptcha.Visible && !reqcontact.Visible && !reqmail.Visible && !reqpass.Visible && !reqreg.Visible && !reqretype.Visible && !requser.Visible)
            {
                DialogResult dr = MessageBox.Show("Registered Successfully!","Success",MessageBoxButtons.OK);
                if(dr == DialogResult.OK)
                {
                    LOGIN frm = new LOGIN(); 
                    frm.Show();
                    this.Hide();
                }
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LOGIN frm = new LOGIN();
            frm.Show();
            this.Hide();
        }
    }
}
