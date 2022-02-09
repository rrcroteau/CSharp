using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//use the DB capabilities to get access to SQL server
using System.Data;
using System.Data.SqlClient;
using SE256_Lab_RonC.App_Code; //add this to get access to App Code folder

namespace SE256_Lab_RonC
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            //I am using a LITERAL to show the search results on my page
            Dance1 temp = new Dance1();

            //create the DR object to then fill it using SearchDances method
            SqlDataReader dr = null;

            dr = temp.SearchDances(txtDanceName.Text, txtMusic.Text);

            //start the table
            litResults.Text = "<table>";
            //create a header row
            litResults.Text += "<caption>Search Results</caption><th>Dance Name</th><th>Choreographer First Name</th><th>Choreographer Last Name</th><th>Music</th><th>Artist</th><th>Line or Partner</th><th>Difficulty</th><th>Steps</th><th>Walls</th>";

            //loop through the results and add each record to its own row
            while (dr.Read())
            {
                litResults.Text +=
                    "<tr>" +
                    "<td>" + dr["DanceName"].ToString() + "</td>" +
                    "<td>" + dr["Choreo1FName"].ToString() + "</td>" +
                    "<td>" + dr["Choreo1LName"].ToString() + "</td>" +
                    "<td>" + dr["Music"].ToString() + "</td>" +
                    "<td>" + dr["Artist"].ToString() + "</td>" +
                    "<td>" + dr["LineOrPartner"].ToString() + "</td>" +
                    "<td>" + dr["Difficulty"].ToString() + "</td>" +
                    "<td>" + dr["Steps"].ToString() + "</td>" +
                    "<td>" + dr["Walls"].ToString() + "</td>" +
                    "</tr>"; //I am not showing the edit button in this view, as this is an unverified user on the main page
            }

            //now that the reader is done, close the table
            litResults.Text += "</table>";
        }
    }
}