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
            Person temp = new Person();

            //collect data from form to fill in person
            temp.FName = txtFName.Text;
            temp.MName = txtMName.Text;
            temp.LName = txtLName.Text;
            temp.Street1 = txtStreet1.Text;
            temp.Street2 = txtStreet2.Text;
            temp.City = txtCity.Text;
            temp.State = txtState.Text;
            temp.Zip = txtZip.Text;
            temp.Phone = txtPhone.Text;
            temp.Email = txtEmail.Text;

            if (temp.Feedback.Contains("ERROR:"))
            {
                lblFeedback.Text = temp.Feedback;
            }

            else
            {
                //output info about person to prove the data was collected
                lblFeedback.Text = $"{temp.FName} {temp.MName} {temp.LName}\n" +
                                   $"{temp.Street1}\n" +
                                   $"{temp.Street2}\n" +
                                   $"{temp.City}, {temp.State} {temp.Zip}\n" +
                                   $"{temp.Phone} | {temp.Email} was added.";
            }

            
        }

    }
}
