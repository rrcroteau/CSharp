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

namespace SE256_Lab_RonC.Backend
{
    public partial class LineDanceMgr : System.Web.UI.Page
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

            if (!IsPostBack)//this ensures this only happens on loading and not when the user is making selections on the page
            {
                calDateChoreographed.SelectedDate = DateTime.Now.AddDays(1); //this sets the selected date to a future date so the user has to enter a date and not bypass validation
                Populate_MonthList();//populate the drop down
                Populate_YearList();//populate the drop down
            }

            //check to see if there is a DanceID in the URL, and if so, pull up that record (in essence, when we click the Edit in the search results)
            string strDanceID;
            int intDanceID;

            if ((!IsPostBack) && Request.QueryString["DanceID"] != null)
            {
                //since there is an ID, we don't need the ADD button to show
                BtnAdd.Visible = false;
                BtnAdd.Enabled = false;

                strDanceID = Request.QueryString["DanceID"].ToString();
                lblDance_ID.Text = strDanceID;

                intDanceID = Convert.ToInt32(strDanceID);

                //create a Dance object and fill it based on the DanceID
                Dance1 temp = new Dance1();
                SqlDataReader dr = temp.FindOneDance(intDanceID);

                while (dr.Read())
                {
                    txtDanceName.Text = dr["DanceName"].ToString();
                    txtChoreo1First.Text = dr["Choreo1FName"].ToString();
                    txtChoreo1Last.Text = dr["Choreo1LName"].ToString();
                    txtChoreo2First.Text = dr["Choreo2FName"].ToString();
                    txtChoreo2Last.Text = dr["Choreo2LName"].ToString();
                    txtChoreo3First.Text = dr["Choreo3FName"].ToString();
                    txtChoreo3Last.Text = dr["Choreo3LName"].ToString();
                    txtMusic.Text = dr["Music"].ToString();
                    txtArtist.Text = dr["Artist"].ToString();
                    rbLinePartner.SelectedValue = dr["LineOrPartner"].ToString();
                    drpDifficulty.SelectedValue = dr["Difficulty"].ToString();
                    txtSteps.Text = dr["Steps"].ToString();
                    txtWalls.Text = dr["Walls"].ToString();

                    //set the calendar to the appropriate date
                    calDateChoreographed.SelectedDate = DateTime.Parse(dr["DateChoreo"].ToString()).Date;
                    calDateChoreographed.VisibleDate = calDateChoreographed.SelectedDate;

                    //set the values of the dropdown to match the date in the DB --Convert to string to use .Month/.Year, then from the int back to string again to assign to SelectedValue
                    drpCalMonth.SelectedValue = DateTime.Parse(dr["DateChoreo"].ToString()).Month.ToString();
                    drpCalYear.SelectedValue = DateTime.Parse(dr["DateChoreo"].ToString()).Year.ToString();


                    ////the code to deal with the radio button
                    //if (dr["LineOrPartner"].ToString() == "Line")
                    //{
                    //    rbLinePartner.SelectedValue = "1";
                    //}
                    //else
                    //{
                    //    rbLinePartner.SelectedValue = "2";
                    //}

                }

            }
            else if ((IsPostBack) && Request.QueryString["DanceID"] != null)
            {
                //this is so that it doesn't hide my update and delete buttons when there is a DanceID and the site posts back due to a calendar picker change
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
            Dance1 temp = new Dance1    //create a temp dance object a run contstructor
            {

                //set the value in the text/calendar to the appropriate class attr
                DanceName = txtDanceName.Text,
                Choreo1FName = txtChoreo1First.Text,
                Choreo1LName = txtChoreo1Last.Text,
                Choreo2FName = txtChoreo2First.Text,
                Choreo2LName = txtChoreo2Last.Text,
                Choreo3FName = txtChoreo3First.Text,
                Choreo3LName = txtChoreo3Last.Text,
                Music = txtMusic.Text,
                Artist = txtArtist.Text,
                Difficulty = drpDifficulty.Text,
                DateChoreo = calDateChoreographed.SelectedDate
            };


            //determine what the line or partner value should be based on the radio button selection
            if (rbLinePartner.SelectedValue == "1")
            {
                temp.LineOrPartner = "Line";
            }

            else
            {
                temp.LineOrPartner = "Partner";
            }

            //parse the strings to ints where necessary (Steps and Walls)
            if (Int32.TryParse(txtSteps.Text, out Int32 intSteps))  //uses inline declartion of temp used intSteps var
            {
                temp.Steps = intSteps;
            }

            if (Int32.TryParse(txtWalls.Text, out Int32 intWalls))
            {
                temp.Walls = intWalls;
            }


            //set the feedback strings based on whether or not there are errors
            if (temp.Feedback.Contains("ERROR"))
            {
                lblFeedback.Text = temp.Feedback;
            }
            else
            {
                lblFeedback.Text = temp.AddARecord(); //if there are no errors, attempt to add the record to the DB and return the result string to feedback lbl
            }
        }

        //testing out populating some drop down lists for month/year to make the built-in ASP calendar less cumbersome (these are called on page load when not Postback)
        protected void Populate_MonthList()
        {
            //Add each month to the list based on system gathered information (uses the names of the months according to the system language
            var dtf = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
            for (int i = 1; i <= 12; i++)
                drpCalMonth.Items.Add(new ListItem(dtf.GetMonthName(i), i.ToString()));

            //Make the current month selected item in the list
            drpCalMonth.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
        }


        protected void Populate_YearList()
        {
            //Year list can be changed by changing the lower and upper 
            //limits of the For statement    
            for (int intYear = DateTime.Now.Year - 50; intYear <= DateTime.Now.Year; intYear++)
            {
                drpCalYear.Items.Add(intYear.ToString());
            }

            //Make the current year selected item in the list
            drpCalYear.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;
        }

        protected void Set_Calendar(object sender, EventArgs e)
        {
            int year = int.Parse(drpCalYear.SelectedValue); //sets the year selected in the drop down
            int month = int.Parse(drpCalMonth.SelectedValue);//sets the month selected in the drop down
            calDateChoreographed.TodaysDate = new DateTime(year, month, 1); //sets the calendar to the month/year selected with the dropdowns (1st day of month by default)
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Dance1 temp = new Dance1    //create a temp dance object a run contstructor
            {
                //set the value in the text/calendar to the appropriate class attr
                Dance_ID = Int32.Parse(lblDance_ID.Text),
                DanceName = txtDanceName.Text,
                Choreo1FName = txtChoreo1First.Text,
                Choreo1LName = txtChoreo1Last.Text,
                Choreo2FName = txtChoreo2First.Text,
                Choreo2LName = txtChoreo2Last.Text,
                Choreo3FName = txtChoreo3First.Text,
                Choreo3LName = txtChoreo3Last.Text,
                Music = txtMusic.Text,
                Artist = txtArtist.Text,
                Difficulty = drpDifficulty.SelectedValue,
                LineOrPartner = rbLinePartner.SelectedValue,
                DateChoreo = calDateChoreographed.SelectedDate
            };
     
            //parse the strings to ints where necessary (Steps and Walls)
            if (Int32.TryParse(txtSteps.Text, out Int32 intSteps))  //uses inline declartion of temp used intSteps var
            {
                temp.Steps = intSteps;
            }

            if (Int32.TryParse(txtWalls.Text, out Int32 intWalls))
            {
                temp.Walls = intWalls;
            }


            //set the feedback strings based on whether or not there are errors
            if (temp.Feedback.Contains("ERROR"))
            {
                lblFeedback.Text = temp.Feedback;
            }
            else
            {
                lblFeedback.Text = temp.UpdateARecord(); //if there are no errors, attempt to add the record to the DB and return the result string to feedback lbl
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Int32 intDanceID = Convert.ToInt32(lblDance_ID.Text); //Get the ID from the label

            //create a temp Dance obj to use the delete method
            Dance1 temp = new Dance1();

            //use the DanceID to pass it to the delete function and return the feeback to the feedback label
            lblFeedback.Text = temp.DeleteOneDance(intDanceID);

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Backend/ControlPanel"); //send user back to control panel
        }
    }
}