using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinBook_Croteau
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BtnDelete.Enabled = false;
            BtnDelete.Visible = false;
            BtnUpdate.Enabled = false;
            BtnUpdate.Visible = false;
        }

        /// <summary>
        /// NEW - Constructor that Receives an EBook ID....this means we need to look up the data and populate fields (View/Edit/Del)
        /// </summary>
        /// <param name="intEBook_ID"></param>
        public Form1(int intEBook_ID)
        {
            InitializeComponent();  //Creates and init's all form objects

            //because this is existing data, we don't want to add anything
            btnAdd.Enabled = false;
            btnAdd.Visible = false;



            //Gather info about this one person and store it in a datareader
            EBook temp = new EBook();
            SqlDataReader dr = temp.FindOneEBook(intEBook_ID);

            //Use that info to fill out the form
            //Loop thru the records stored in the reader 1 record at a time
            // Note that since this is based on one person's ID, then we
            //  should only have one record
            while (dr.Read())
            {
                //Take the Name(s) from the datareader and copy them
                // into the appropriate text fields
                txtTitle.Text = dr["Title"].ToString();
                txtFName.Text = dr["AuthorFirst"].ToString();
                txtLName.Text = dr["AuthorLast"].ToString();
                txtEmail.Text = dr["Email"].ToString();
                txtPages.Text = dr["Pages"].ToString();
                txtBookmarkPage.Text = dr["BookmarkPage"].ToString();
                txtPrice.Text = dr["Price"].ToString();

                dtpDatePublished.Value = DateTime.Parse(dr["DatePublished"].ToString());
                dtpDateRentalExpires.Value = DateTime.Parse(dr["DateRentalExpires"].ToString());

                //We added this one to store the ID in a new label
                lblEBook_ID.Text += dr["EBook_ID"].ToString();
            }


        }


        private void btnFillInForm_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "Hey, it's a Book";
            txtFName.Text = "Joe";
            txtLName.Text = "Duffy";
            txtEmail.Text = "me@myemail.co";
            txtPages.Text = "70";
            dtpDatePublished.Value = DateTime.Now;
            txtBookmarkPage.Text = "0";
            dtpDateRentalExpires.Value = DateTime.Now.AddDays(14);
            txtPrice.Text = "9.99";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lblFeedback.Text = "";
            EBook temp = new EBook();


            temp.Title = txtTitle.Text;
            temp.AuthFName = txtFName.Text;
            temp.AuthLName = txtLName.Text;
            temp.Email = txtEmail.Text;
    

            //get date/times from pickers
            temp.DatePublished = dtpDatePublished.Value;
            temp.DateRentalExpires = dtpDateRentalExpires.Value;

            //convert the string values of # to ints for validation/storage
            int intTempPages;
            bool blnResult1 = Int32.TryParse(txtPages.Text, out intTempPages);

            if (blnResult1 == false)
            {
                lblFeedback.Text += "\nSorry, incorrect page #. Please try again. (ex. 214)";
            }

            else
            {
                temp.Pages = intTempPages;
            }

            int intBMPage;
            bool blnResult2 = Int32.TryParse(txtBookmarkPage.Text, out intBMPage);

            if (blnResult2 == false)
            {
                lblFeedback.Text += "\nSorry, incorrect bookmark page #. Please try again. (ex. 214)";
            }

            else
            {
                temp.BookmarkPage = intBMPage;
            }

            //convert the string values of # to double for validation/storage
            double dblTempPrice;
            bool blnResult3 = Double.TryParse(txtPrice.Text, out dblTempPrice);

            if (blnResult3 == false)
            {
                lblFeedback.Text += "\nPlease enter a positive amount for Price (ex:  9.99)";
            }

            else
            {
                temp.Price = dblTempPrice;
            }

            if (temp.Feedback.Contains("ERROR:"))
            {
                lblFeedback.Text += temp.Feedback;
            }

            else
            {
                lblFeedback.Text = temp.AddARecord();
                
            }


        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            lblFeedback.Text = "";
            EBook temp = new EBook();


            temp.Title = txtTitle.Text;
            temp.AuthFName = txtFName.Text;
            temp.AuthLName = txtLName.Text;
            temp.Email = txtEmail.Text;
            temp.EBook_ID = Convert.ToInt32(lblEBook_ID.Text);


            //get date/times from pickers
            temp.DatePublished = dtpDatePublished.Value;
            temp.DateRentalExpires = dtpDateRentalExpires.Value;

            //convert the string values of # to ints for validation/storage
            int intTempPages;
            bool blnResult1 = Int32.TryParse(txtPages.Text, out intTempPages);

            if (blnResult1 == false)
            {
                lblFeedback.Text += "\nSorry, incorrect page #. Please try again. (ex. 214)";
            }

            else
            {
                temp.Pages = intTempPages;
            }

            int intBMPage;
            bool blnResult2 = Int32.TryParse(txtBookmarkPage.Text, out intBMPage);

            if (blnResult2 == false)
            {
                lblFeedback.Text += "\nSorry, incorrect bookmark page #. Please try again. (ex. 214)";
            }

            else
            {
                temp.BookmarkPage = intBMPage;
            }

            //convert the string values of # to double for validation/storage
            double dblTempPrice;
            bool blnResult3 = Double.TryParse(txtPrice.Text, out dblTempPrice);

            if (blnResult3 == false)
            {
                lblFeedback.Text += "\nPlease enter a positive amount for Price (ex:  9.99)";
            }

            else
            {
                temp.Price = dblTempPrice;
            }

            if (temp.Feedback.Contains("ERROR:"))
            {
                lblFeedback.Text += temp.Feedback;
            }

            else
            {
                lblFeedback.Text = temp.UpdateARecord();

            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Int32 intEBook_ID = Convert.ToInt32(lblEBook_ID.Text);  //Get the ID from the Label

            //Create a EBook so we can use the delete method
            EBook temp = new EBook();

            //Use the EBook ID and pass it to the delete function
            // and get the number of records deleted
            lblFeedback.Text = temp.DeleteOneEBook(intEBook_ID);
        }
    }
}
