using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6_Croteau
{
    public partial class ControlPanel : Form
    {
        public ControlPanel()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //Create a new instance of form1 (Add form) and make it visible (show)
            Form1 temp = new Form1();
            temp.Show();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //Create a new instance of SearchMgr (Add form) and make it visible (show)
            SearchMgr temp = new SearchMgr();
            temp.Show();
        }
    }
}
