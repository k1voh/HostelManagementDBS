using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;

namespace HostelManagement
{
    public partial class C2 : Form
    {
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        string name;
        string reg;
        public C2(string regno)
        {
            InitializeComponent();
            reg = regno;
        }

        private void C2_Load(object sender, EventArgs e)
        {

        }

        private void issuelabel_Click(object sender, EventArgs e)
        {

        }
    }
}
