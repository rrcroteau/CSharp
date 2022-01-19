using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE256_Lab_RonC.Backend
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtUName.Text == "Scott" && txtPW.Text == "NEIT")
            {
                //this means there is a match for both the username and the password
                Session["UName"] = txtUName.Text;
                Session["LoggedIn"] = "TRUE";
                //lblFeedback.Text = "Successful Login"; //USER WILL NO LONGER SEE THIS, THEY ARE BEING REDIRECTED
                Response.Redirect("~/Backend/ControlPanel.aspx"); //send the user to the control panel since they put in the right username/pw combo
            }

            else
            {
                //either the username or the password was incorrect -- clearn any potential session vars and give feedback
                Session["UName"] = "";
                Session["LoggedIn"] = "FALSE";
                lblFeedback.Text = "Login Failed...Please reenter a valid username and password combination";
            }
        }
    }
}