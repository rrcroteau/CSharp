using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Use these namespaces to include DB capabilities for generic components and SQL Server
using System.Data;
using System.Data.SqlClient;
using SE256_Activity_RonC.App_Code; //must add this to access items in the App Code folder

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

            //*****
            //Code to see if there is an existing EBook ID so we can display the information on the screen
            //*****
            string strEBook_ID;
            int intEBook_ID;

            //Check the URL to see if there is an EBook_ID...if so, display the information for that EBook
            if ((!IsPostBack) && Request.QueryString["EBook_ID"] != null)
            {
                //since there is an ID, we don't need the ADD button to show
                BtnAdd.Visible = false;
                BtnAdd.Enabled = false;

                strEBook_ID = Request.QueryString["EBook_ID"].ToString();
                lblEbook_ID.Text = strEBook_ID; // this is the label at the top of the form

                intEBook_ID = Convert.ToInt32(strEBook_ID);

                //Fill the information on the form based on the ID
                EBook temp = new EBook();
                SqlDataReader dr = temp.FindOneEBook(intEBook_ID);

                while (dr.Read())
                {
                    txtTitle.Text = dr["Title"].ToString();
                    txtAuthorFirst.Text = dr["AuthorFirst"].ToString();
                    txtAuthorLast.Text = dr["AuthorLast"].ToString();
                    txtAuthorEmail.Text = dr["Email"].ToString();
                    txtPages.Text = dr["Pages"].ToString();
                    txtPrice.Text = dr["Price"].ToString();
                    txtBookmarkPage.Text = dr["BookmarkPage"].ToString();

                    calDatePublished.SelectedDate = DateTime.Parse(dr["DatePublished"].ToString()).Date;
                    calRentalExpires.SelectedDate = DateTime.Parse(dr["DatePublished"].ToString()).Date;
                    calDatePublished.VisibleDate = calDatePublished.SelectedDate;
                    calRentalExpires.VisibleDate = calRentalExpires.SelectedDate;
                }
            }
            else
            {
                //since there is no Book ID, it must be an add, so we can hide the UPDATE and DELETE buttons
                BtnUpdate.Visible = false;
                BtnUpdate.Enabled = false;
                BtnDelete.Visible = false;
                BtnDelete.Enabled = false;
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

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            EBook temp = new EBook(); //construct a temp book to hold the book data which will be transferred into the DB

            temp.EBook_ID = Int32.Parse(lblEbook_ID.Text);
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
            if (Double.TryParse(txtPrice.Text, out dblPrice))
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
                lblFeedback.Text = temp.UpdateARecord();
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Int32 intEBook_ID = Convert.ToInt32(lblEbook_ID.Text); //get the EBook_ID from the label

            //create an EBook so we can use the Delete method
            EBook temp = new EBook();

            //use the EBook ID to delete the record and return the feedback to the label
            lblFeedback.Text = temp.DeleteOneEBook(intEBook_ID);

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            //send user back to the control panel
            Response.Redirect("~/Backend/ControlPanel");
        }
    }
}