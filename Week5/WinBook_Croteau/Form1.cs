using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinBook_Croteau
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFillInForm_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "Guide to Me";
            txtFName.Text = "Joe";
            txtLName.Text = "Mama";

            dtpDatePublished.Value = DateTime.Now;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Book temp = new Book();


            temp.Title = txtTitle.Text;
            temp.AuthFName = txtFName.Text;
            temp.AuthLName = txtLName.Text;
            temp.DatePublished = dtpDatePublished.Value;

            MessageBox.Show(temp.Title + " written by " + temp.AuthFName + " " + temp.AuthLName + " on " + temp.DatePublished.ToShortDateString());
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
