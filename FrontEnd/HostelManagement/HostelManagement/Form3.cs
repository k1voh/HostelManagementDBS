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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.passTB.PasswordChar = '*';
            this.retypepassTB.PasswordChar = '*';
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (mailTB.Text == string.Empty)
            {
                reqmail.Visible = true;
            }
            else
            {
                reqmail.Visible = false;
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
            if (regTB.Text == string.Empty)
            {
                reqreg.Visible = true;
            }
            else
            {
                reqreg.Visible = false;
            }
            if(!reqmail.Visible && (!mailTB.Text.Contains("@") ||  !mailTB.Text.Contains(".com"))) 
            { 
                invalidmail.Visible = true;
            }
            else
            {
                invalidmail.Visible = false;
            }
            if(!reqreg.Visible && (!IsNumeric(regTB.Text) || regTB.Text.Length > 9))
            {
                invalidreg.Visible = true;
            }
            else
            {
                invalidreg.Visible = false;
            }
            if (!reqmail.Visible && !reqpass.Visible && !reqretype.Visible && !reqreg.Visible && !invalidmail.Visible && !invalidreg.Visible)
            {
                DialogResult dr = MessageBox.Show("Password Reset Successfully!", "Success", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    LOGIN frm = new LOGIN();
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
            }
        }

        private void reqretype_Click(object sender, EventArgs e)
        {

        }
    }
}
