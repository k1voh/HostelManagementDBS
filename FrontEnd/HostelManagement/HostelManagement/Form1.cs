﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

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
            if(!reqcaptcha.Visible && !reqpass.Visible && !reqreg.Visible){
                if(regTB.Text[0]=='2'){
                    long x = 0;
                    long.TryParse(regTB.Text, out x);
                    Profile frm = new Profile(x);
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();   
                }
                else if(regTB.Text[0]=='0'){
                    long x = 0;
                    long.TryParse(regTB.Text, out x);
                    ProfileAdmin frm = new ProfileAdmin(x);
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 frm = new Form2();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 fr = new Form3();
            this.Hide();
            fr.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
