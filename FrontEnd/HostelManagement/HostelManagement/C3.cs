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
    public partial class C3 : Form
    {
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        string name;
        string reg;
        public C3(string regno)
        {
            InitializeComponent();
            reg = regno;
        }

        private void C3_Load(object sender, EventArgs e)
        {

        }
    }
}
