using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_Croteau
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            //Build or Construct an instance of a person called Temp
            Person temp = new Person
            {

                //collect data from form to fill in person
                FName = txtFName.Text,
                MName = txtMName.Text,
                LName = txtLName.Text,
                Street1 = txtStreet1.Text,
                Street2 = txtStreet2.Text,
                City = txtCity.Text,
                State = txtState.Text,
                Zip = txtZip.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text
            };

            if (temp.Feedback.Contains("ERROR:"))
            {
                lblFeedback.Text = temp.Feedback;
            }

            else
            {   

                if (temp.MName == "" && temp.Street2 == "")
                {
                    //output info without the MName and Street2 as they weren't entered
                    lblFeedback.Text = $"{temp.FName} {temp.LName}\n" +
                                       $"{temp.Street1}\n" +
                                       $"{temp.City}, {temp.State} {temp.Zip}\n" +
                                       $"\n{temp.Phone} | {temp.Email}\n" +
                                       $"\n\n The person above was added.";
                }

                else if (temp.MName == "")
                {
                    //output info without the MName as it wasn't entered
                    lblFeedback.Text = $"{temp.FName} {temp.LName}\n" +
                                       $"{temp.Street1}\n" +
                                       $"{temp.Street2}\n" +
                                       $"{temp.City}, {temp.State} {temp.Zip}\n" +
                                       $"\n{temp.Phone} | {temp.Email}\n" +
                                       $"\n\n The person above was added.";
                }

                else if (temp.Street2 == "")
                {
                    //output info without Street2 as it wasn't entered
                    lblFeedback.Text = $"{temp.FName} {temp.MName} {temp.LName}\n" +
                                       $"{temp.Street1}\n" +
                                       $"{temp.City}, {temp.State} {temp.Zip}\n" +
                                       $"\n{temp.Phone} | {temp.Email}\n" +
                                       $"\n\n The person above was added.";
                }

                else 
                {
                    //outputs all data because all fields have been entered
                    lblFeedback.Text = $"{temp.FName} {temp.MName} {temp.LName}\n" +
                                       $"{temp.Street1}\n" +
                                       $"{temp.Street2}\n" +
                                       $"{temp.City}, {temp.State} {temp.Zip}\n" +
                                       $"\n{temp.Phone} | {temp.Email}\n" +
                                       $"\n\n The person above was added.";
                }
         
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
            txtEmail.Text = "me@mail.edu";
        }
    }
}
