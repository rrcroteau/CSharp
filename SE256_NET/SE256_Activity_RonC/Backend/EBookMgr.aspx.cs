using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SE256_Activity_RonC.App_Code; //must add this to access to items in the App Code folder

namespace SE256_Activity_RonC.Backend
{
    public partial class EBookMgr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the user is already logged in, keep them here
            if (Session["LoggedIn"] != null && Session["LoggedIn"].ToString() == "TRUE")
            {
                //do nothing, allowed the user to stay here, as they are logged in properly
            }

            else
            {
                //they are not properly logged in... redirect them back to the login page
                Response.Redirect("~/Backend/Default.aspx");
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            EBook temp = new EBook(); //construct a temp book to hold the book data which will be transferred into the DB

            temp.Title = txtTitle.Text;
            temp.AuthFName = txtAuthorFirst.Text;
            temp.AuthLName = txtAuthorLast.Text;
            temp.Email = txtAuthorEmail.Text;
            temp.DatePublished = calDatePublished.SelectedDate; //using a calendar to select the date
            temp.DateRentalExpires = calRentalExpires.SelectedDate; 

            //conduct needed string to int/double parses
            Int32 intPages;
            if (Int32.TryParse(txtPages.Text, out intPages))
            {
                temp.Pages = intPages;
            }

            Double dblPrice;
            if(Double.TryParse(txtPrice.Text, out dblPrice))
            {
                temp.Price = dblPrice;
            }

            if (Int32.TryParse(txtBookmarkPage.Text, out Int32 intBookmarkPage)) //intialized the variable inline for testing purpose
            {
                temp.BookmarkPage = intBookmarkPage;
            }

            if (temp.Feedback.Contains("ERROR:")) //if there was an error found, output that to the user with the feedback label
            {
                lblFeedback.Text = temp.Feedback;
            }

            else //if no error, add the record to the database
            {
                lblFeedback.Text = temp.AddARecord(); 
            }

            

        }
    }
}