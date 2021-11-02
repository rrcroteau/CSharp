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

        public string Title
        {
            get { return title;  }
            set { title = value; }
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
