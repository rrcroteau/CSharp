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
            //Build or Construct an instance of a Customer
            Customer temp = new Customer
            {

                //collect data from form to fill in customer
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
                InstagramURL = txtInstagramURL.Text,
                
                //get date/time from picker
                CustomerSince = dtpCustomerSince.Value,
                

            };

            //convert the string values of # to double for validation/storage
            double dblTempTotalPurchase;
            bool blnResult1 = Double.TryParse(txtTotalPurchases.Text, out dblTempTotalPurchase);

            if (blnResult1 == false)
            {
                lblFeedback.Text += "\nPlease enter a positive amount for Total Purchases (ex:  9.99)";
            }

            else
            {
                temp.TotalPurchases = dblTempTotalPurchase;
            }

            //convert the string values of # to int for validation/storage
            int intRewardsEarned;
            blnResult1 = Int32.TryParse(txtRewardsEarned.Text, out intRewardsEarned);

            if (blnResult1 == false)
            {
                lblFeedback.Text += "\nPlease enter a positive whole number for Rewards Earned (ex:  5)";
            }

            else
            {
                temp.RewardsEarned = intRewardsEarned;
            }

            if (temp.Feedback.Contains("ERROR:"))
            {
                lblFeedback.Text = temp.Feedback;
            }

            else
            {
                lblFeedback.Text = ""; //set this to empty to facilitate adding the record added data below 

                if (temp.MName == "" && temp.Street2 == "")
                {
                    //output info without the MName and Street2 as they weren't entered
                    lblFeedback.Text += $"The person below was added:\n\n" +
                                        $"{temp.FName} {temp.LName}\n" +
                                        $"{temp.Street1}\n" +
                                        $"{temp.City}, {temp.State} {temp.Zip}\n" +
                                        $"\nPHONE: {temp.Phone} | CELL: {temp.CellPhone}\n" +
                                        $"{temp.Email} | {temp.InstagramURL}\n" +
                                        $"Customer Since: {temp.CustomerSince.ToShortDateString()} | Total Purchases: ${temp.TotalPurchases} | Rewards Earned: {temp.RewardsEarned}";

                    if (chkDiscountMember.Checked)
                    {
                        lblFeedback.Text += "\nDiscount Member: Yes";
                    }

                    else
                    {
                        lblFeedback.Text += "\nDiscount Member: No";
                    }
                }

                else if (temp.MName == "")
                {
                    //output info without the MName as it wasn't entered
                    lblFeedback.Text += $"The person below was added:\n\n" +
                                        $"{temp.FName} {temp.LName}\n" +
                                        $"{temp.Street1}\n" +
                                        $"{temp.Street2}\n" +
                                        $"{temp.City}, {temp.State} {temp.Zip}\n" +
                                        $"\nPHONE: {temp.Phone} | CELL: {temp.CellPhone}\n" +
                                        $"{temp.Email} | {temp.InstagramURL}\n" +
                                        $"Customer Since: {temp.CustomerSince.ToShortDateString()} | Total Purchases: ${temp.TotalPurchases} | Rewards Earned: {temp.RewardsEarned}";

                    if (chkDiscountMember.Checked)
                    {
                        lblFeedback.Text += "\nDiscount Member: Yes";
                    }

                    else
                    {
                        lblFeedback.Text += "\nDiscount Member: No";
                    }
                }

                else if (temp.Street2 == "")
                {
                    //output info without Street2 as it wasn't entered
                    lblFeedback.Text += $"The person below was added:\n\n" +
                                        $"{temp.FName} {temp.MName} {temp.LName}\n" +
                                        $"{temp.Street1}\n" +
                                        $"{temp.City}, {temp.State} {temp.Zip}\n" +
                                        $"\nPHONE: {temp.Phone} | CELL: {temp.CellPhone}\n" +
                                        $"{temp.Email} | {temp.InstagramURL}\n" +
                                        $"Customer Since: {temp.CustomerSince.ToShortDateString()} | Total Purchases: ${temp.TotalPurchases} | Rewards Earned: {temp.RewardsEarned}";

                    if (chkDiscountMember.Checked)
                    {
                        lblFeedback.Text += "\nDiscount Member: Yes";
                    }

                    else
                    {
                        lblFeedback.Text += "\nDiscount Member: No";
                    }
                }

                else 
                {
                    //outputs all data because all fields have been entered
                    lblFeedback.Text += $"The person below was added:\n\n" + 
                                        $"{temp.FName} {temp.MName} {temp.LName}\n" +
                                        $"{temp.Street1}\n" +
                                        $"{temp.Street2}\n" +
                                        $"{temp.City}, {temp.State} {temp.Zip}\n" +
                                        $"\nPHONE: {temp.Phone} | CELL: {temp.CellPhone}\n" +
                                        $"{temp.Email} | {temp.InstagramURL}\n" +
                                        $"Customer Since: {temp.CustomerSince.ToShortDateString()} | Total Purchases: ${temp.TotalPurchases} | Rewards Earned: {temp.RewardsEarned}";

                    if (chkDiscountMember.Checked)
                    {
                        lblFeedback.Text += "\nDiscount Member: Yes";
                    }

                    else
                    {
                        lblFeedback.Text += "\nDiscount Member: No";
                    }
                }
         
            }

        }

        private void btnFillData_Click(object sender, EventArgs e)
        {
            txtFName.Text = "Paul";
            txtMName.Text = "R";
            txtLName.Text = "Mumbles";
            txtStreet1.Text = "1 My Street";
            txtStreet2.Text = "Apt 3";
            txtCity.Text = "Warwick";
            txtState.Text = "RI";
            txtZip.Text = "99999";
            txtPhone.Text = "1234567890";
            txtCellPhone.Text = "0987654321";
            txtEmail.Text = "me@mail.edu";
            txtInstagramURL.Text = "instagram.com/itsRonC";
            dtpCustomerSince.Value = DateTime.Now;
            txtTotalPurchases.Text = "99.99";
         }

    }
}
