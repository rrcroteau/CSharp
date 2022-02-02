using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Use these namespaces to include DB capabilities for generic components and SQL Server
using System.Data;
using System.Data.SqlClient;
using SE256_Activity_RonC.App_Code;//to get easy access to classes in the APP CODE folder


namespace SE256_Activity_RonC.Backend
{
    public partial class EBookSearch : System.Web.UI.Page
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

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            //create an EBook obj that will be the vehicle to pass the information to the DS/DR 
            EBook temp = new EBook();


            //*****
            //Fill a DS and bind it to a GridView object
            //*****
            //fill a DS obj
            DataSet ds = temp.SearchEBooks_DS(txtTitle.Text, txtAuthorLast.Text);

            dgResults.DataSource = ds; //point GV to the DS
            dgResults.DataMember = ds.Tables[0].TableName; //point GV to the one table
            dgResults.DataBind(); //bind the data 

            //*****
            //Fill a DR and bind it to a Repeater object
            //*****
            SqlDataReader dr = null;

            //fill the DR with the results
            dr = temp.SearchEBooks_DR(txtTitle.Text, txtAuthorLast.Text);

            //point the Reader to the DR and bind the data
            rptSearch.DataSource = dr;
            rptSearch.DataBind();

            //*****
            //Fill a DR and use it to fill a Literal obj
            //*****

            //fill the DR with the results
            dr = temp.SearchEBooks_DR(txtTitle.Text, txtAuthorLast.Text);

            //I will create an HTML table on the fly with LITERAL HTML using the data to fill in the data

            //start a table
            litResults.Text = "<table>";
            //create a header row by adding to the litResults.Text string
            litResults.Text += "<th>Title</th><th>First Name</th><th>Last Name</th><th>Date Published</th><th>Edit Link</th>";

            //while there is still data in the reader, loop through it and create the table data with it, on row of data goes on one row of the table
            while (dr.Read())
            {
                litResults.Text +=
                    "<tr>" +
                    "<td>" + dr["Title"].ToString() + "</td>" +
                    "<td>" + dr["AuthorFirst"].ToString() + "</td>" +
                    "<td>" + dr["AuthorLast"].ToString() + "</td>" +
                    "<td>" + dr["DatePublished"].ToString() + "</td>" +
                    "<td>" + "<a href='EBookMgr.aspx?EBook_ID=" + dr["EBook_ID"].ToString() + "'>Edit</a></td>" +
                    "<tr>";
            }

            //once done looping through the data, close the table
            litResults.Text += "</table>";


        }
    }
}