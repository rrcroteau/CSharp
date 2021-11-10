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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFillInForm_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "Guide to Me";
            txtFName.Text = "Joe";
            txtLName.Text = "Mama";
            txtEmail.Text = "me@myemail.co";
            txtPages.Text = "70";
            dtpDatePublished.Value = DateTime.Now;
            txtBookmarkPage.Text = "0";
            dtpDateRentalExpires.Value = DateTime.Now.AddDays(14);
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
            bool blnResult = Int32.TryParse(txtPages.Text, out intTempPages);

            if (blnResult == false)
            {
                lblFeedback.Text += "\nSorry, incorrect page #. Please try again. (ex. 214)";
            }

            else
            {
                temp.Pages = intTempPages;
            }

            int intBMPage;
            blnResult = Int32.TryParse(txtBookmarkPage.Text, out intBMPage);

            if (blnResult == false)
            {
                lblFeedback.Text += "\nSorry, incorrect bookmark page #. Please try again. (ex. 214)";
            }

            else
            {
                temp.BookmarkPage = intBMPage;
            }

            if (temp.Feedback.Contains("ERROR:"))
            {
                lblFeedback.Text += temp.Feedback;    
            }

            else
            {
                lblFeedback.Text = ($"Record Stored: { temp.Title} written by {temp.AuthFName} {temp.AuthLName} on {temp.DatePublished.ToShortDateString()}");
            }


        }

    }
}
