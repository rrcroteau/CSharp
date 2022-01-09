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

namespace Lab6_Croteau
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// NEW - Constructor that Receives an EBook ID....this means we need to look up the data and populate fields (View/Edit/Del)
        /// </summary>
        /// <param name="intPersonID"></param>
        public Form1(int intPersonID)
        {
            InitializeComponent();  //Creates and init's all form objects

            //Gather info about this one person and store it in a datareader
            PersonV2 temp = new PersonV2();
            SqlDataReader dr = temp.FindOnePerson(intPersonID);

            //Use that info to fill out the form
            //Loop thru the records stored in the reader 1 record at a time
            // Note that since this is based on one person's ID, then we
            //  should only have one record
            while (dr.Read())
            {
                //Take the Name(s) from the datareader and copy them
                // into the appropriate text fields
                txtFName.Text = dr["FirstName"].ToString();
                txtMName.Text = dr["Middle"].ToString();
                txtLName.Text = dr["LastName"].ToString();
                txtStreet1.Text = dr["Street1"].ToString();
                txtStreet2.Text = dr["Street2"].ToString();
                txtCity.Text = dr["City"].ToString();
                txtState.Text = dr["State"].ToString();
                txtZip.Text = dr["ZipCode"].ToString();
                txtPhone.Text = dr["Phone"].ToString();
                txtCellPhone.Text = dr["Cell"].ToString();
                txtEmail.Text = dr["Email"].ToString();
                txtInstagramURL.Text = dr["Instagram"].ToString();


                //We added this one to store the ID in a new label
                lblPersonID.Text += dr["PersonID"].ToString();
            }

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            //Build or Construct an instance of a person called Temp
            PersonV2 temp = new PersonV2
            {

                //collect data from form to fill in person
                FName = txtFName.Text.ToUpper(),
                MName = txtMName.Text.ToUpper(),
                LName = txtLName.Text.ToUpper(),
                Street1 = txtStreet1.Text.ToUpper(),
                Street2 = txtStreet2.Text.ToUpper(),
                City = txtCity.Text.ToUpper(),
                State = txtState.Text.ToUpper(),
                Zip = txtZip.Text,
                Phone = txtPhone.Text,
                CellPhone = txtCellPhone.Text,
                Email = txtEmail.Text,
                InstagramURL = txtInstagramURL.Text
            };

            if (temp.Feedback.Contains("ERROR:"))
            {
                lblFeedback.Text = temp.Feedback;
            }

            else
            {
                lblFeedback.Text = temp.AddARecord();
                /*if (temp.MName == "" && temp.Street2 == "")
                {
                    //output info without the MName and Street2 as they weren't entered
                    lblFeedback.Text = $"{temp.FName} {temp.LName}\n" +
                                       $"{temp.Street1}\n" +
                                       $"{temp.City}, {temp.State} {temp.Zip}\n" +
                                       $"Phone: {temp.Phone} | Cell: {temp.CellPhone}\n" +
                                       $"{temp.Email} | {temp.InstagramURL}\n" +
                                       $"\n The person above was added.";
                }

                else if (temp.MName == "")
                {
                    //output info without the MName as it wasn't entered
                    lblFeedback.Text = $"{temp.FName} {temp.LName}\n" +
                                       $"{temp.Street1}\n" +
                                       $"{temp.Street2}\n" +
                                       $"{temp.City}, {temp.State} {temp.Zip}\n" +
                                       $"Phone: {temp.Phone} | Cell: {temp.CellPhone}\n" +
                                       $"{temp.Email} | {temp.InstagramURL}\n" +
                                       $"\n The person above was added.";
                }

                else if (temp.Street2 == "")
                {
                    //output info without Street2 as it wasn't entered
                    lblFeedback.Text = $"{temp.FName} {temp.MName} {temp.LName}\n" +
                                       $"{temp.Street1}\n" +
                                       $"{temp.City}, {temp.State} {temp.Zip}\n" +
                                       $"Phone: {temp.Phone} | Cell: {temp.CellPhone}\n" +
                                       $"{temp.Email} | {temp.InstagramURL}\n" +
                                       $"\n The person above was added.";
                }

                else
                {
                    //outputs all data because all fields have been entered
                    lblFeedback.Text = $"{temp.FName} {temp.MName} {temp.LName}\n" +
                                       $"{temp.Street1}\n" +
                                       $"{temp.Street2}\n" +
                                       $"{temp.City}, {temp.State} {temp.Zip}\n" +
                                       $"Phone: {temp.Phone} | Cell: {temp.CellPhone}\n" +
                                       $"{temp.Email} | {temp.InstagramURL}\n" +
                                       $"\n The person above was added.";
                }*/

            }

        }

        private void btnFillData_Click(object sender, EventArgs e)
        {
            txtFName.Text = "Ron";
            txtMName.Text = "R";
            txtLName.Text = "Croteau";
            txtStreet1.Text = "1 My Street";
            txtStreet2.Text = "Apt 3";
            txtCity.Text = "Warwick";
            txtState.Text = "RI";
            txtZip.Text = "99999";
            txtPhone.Text = "1234567890";
            txtCellPhone.Text = "0987654321";
            txtEmail.Text = "me@mail.edu";
            txtInstagramURL.Text = "instagram.com/itsRonC";
        }

    }
}