using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinBook_Croteau
{
    public partial class SearchMgr : Form
    {
        public SearchMgr()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //Get Data
            EBook temp = new EBook();
            //Perform the search we created in EBook class and store the returned dataset
            DataSet ds = temp.SearchEBooks(txtTitle.Text, txtAuthorLast.Text);

            //Display data (dataset)
            dgvResults.DataSource = ds;                                  //point datagrid to dataset
            dgvResults.DataMember = ds.Tables["Ebooks_Temp"].ToString();     // What table in the dataset?
        }
    }
}
