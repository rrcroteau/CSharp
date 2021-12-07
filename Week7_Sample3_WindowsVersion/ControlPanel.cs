using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week7_Sample3_WindowsVersion
{
    public partial class ControlPanel : Form
    {
        public ControlPanel()
        {
            InitializeComponent();
        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {

        }

        private void btnAddABook_Click(object sender, EventArgs e)
        {
            //Create a new instance of form1 (Add form) and make it visible (show)
            Form1 temp = new Form1();
            temp.Show();
        }

        private void btnSearchBooks_Click(object sender, EventArgs e)
        {
            //Create a new instance of SearchMgr (Search form) and make it visible (show)
            SearchMgr temp = new SearchMgr();
            temp.Show();
        }
    }
}
