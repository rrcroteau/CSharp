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
    public partial class SearchMgr : Form
    {
        public SearchMgr()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //Get Data
            PersonV2 temp = new PersonV2();
            //Perform the search we created in PersonV2 class and store the returned dataset
            DataSet ds = temp.SearchPersons(txtLName.Text, txtState.Text, txtPersonID.Text);

            //Display data (dataset)
            dgvResults.DataSource = ds;                                  //point datagrid to dataset
            dgvResults.DataMember = ds.Tables["Persons_Temp"].ToString();     // What table in the dataset?
        }

        private void dgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Gather the information (Gathers the row clicked, then chooses the first cell's data
            string strPersonID = dgvResults.Rows[e.RowIndex].Cells[0].Value.ToString();

            //Display data in Pop-up
            MessageBox.Show(strPersonID);

            //Convert the string over to an integer
            int intPersonID= Convert.ToInt32(strPersonID);

            //Create the editor form, passing it one EBook's ID and show it
            // NOTE THAT THE ID BEING PASSED WILL CALL THE OVERLOADED VERSION
            // OF THE CONSTRUCTOR...TELL IT, IN ESSENCE THAT WE ARE PULLING UP
            // RATHER THAN ADDING DATA 
            Form1 Editor = new Form1(intPersonID);
            Editor.ShowDialog();
        }
    }
}
