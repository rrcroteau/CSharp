using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBook_Croteau
{
    public class Book
    {
        private string title;
        private string authFName;
        private string authLName;
        private string feedback;
        private DateTime datePublished;

        //Create constructor to initialize variables (so they are not NULL)
        public Book()
        {
            title = "";
            authFName = "";
            authLName = "";
            feedback = "";
            datePublished = DateTime.Now;
        }

        public string Title
        {
            get { return title;  }
            set
            {
                if (Validator.IsEmpty(value) == false)
                {
                    title = value;
                }

                else 
                {
                    Feedback += "ERROR: Please enter a Title, this field cannot be empty.\n";
                }
            }
        }

        public string AuthFName
        {
            get { return authFName; }
            set { authFName = value; }
        }

        public string AuthLName
        {
            get { return authLName; }
            set { authLName = value; }
        }

        public string Feedback
        {
            get { return feedback; }
            set { feedback = value; }
        }

        public DateTime DatePublished
        {
            get { return datePublished; }
            set { datePublished = value; }
        }
    }
}
