using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Added to use Ebook & Validation items
using Week_6_Sample1_DataValidation;

namespace Week7_Sample3_WindowsVersion
{
    public partial class SearchMgr : Form
    {
        public SearchMgr()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Get Data
            EBook temp = new EBook();
            //Perform the search we created in EBook class and store the returned dataset
            DataSet ds = temp.SearchEBooks(txtTitle.Text, txtAuthorLast.Text);

            //Display data (dataset)
            dgvResults.DataSource = ds;                                  //point datagrid to dataset
            dgvResults.DataMember = ds.Tables["Ebooks_Temp"].ToString();     // What table in the dataset?

        }


        /// <summary>
        /// Event-Handler Method - When we double-click a data cell, get the ID and use it to search for the
        ///   whole record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Gather the information (Gathers the row clicked, then chooses the first cell's data
            string strEBook_ID = dgvResults.Rows[e.RowIndex].Cells[0].Value.ToString();

            //Display data in Pop-up
            MessageBox.Show(strEBook_ID);

            //Convert the string over to an integer
            int intEBook_ID = Convert.ToInt32(strEBook_ID);

            //Create the editor form, passing it one EBook's ID and show it
            // NOTE THAT THE ID BEING PASSED WILL CALL THE OVERLOADED VERSION
            // OF THE CONSTRUCTOR...TELL IT, IN ESSENCE THAT WE ARE PULLING UP
            // RATHER THAN ADDING DATA 
            Form1 Editor = new Form1(intEBook_ID);
            Editor.ShowDialog();
        }

    }
}
