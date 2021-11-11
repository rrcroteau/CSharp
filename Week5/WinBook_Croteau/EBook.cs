using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBook_Croteau
{
    class EBook : Book //yay for inheritance!!
    {
        private DateTime dateRentalExpires;
        private int bookmarkPage;

        //default Constructor
        public EBook(): base() //calls the parent constructor
        {
            bookmarkPage = 0;
            dateRentalExpires = DateTime.Now.AddDays(14);
        }

        public DateTime DateRentalExpires
        {
            get { return dateRentalExpires; }

            set
            {
                //needs to be a future date
                if (Validator.IsFutureDate(value))
                {
                    dateRentalExpires = value; //store it
                }

                else
                {
                    //past date, give error
                    feedback += "\nERROR: You must enter a future date for the date the rental expires.";
                }
            }
        }

        public int BookmarkPage
        {
            get { return bookmarkPage; }

            set
            {
                //needs to be between 0 and the number of pages
                if (value >= 0 && value <= Pages)
                {
                    bookmarkPage = value; //store it
                }

                else
                {
                    //give feedback of invalid input
                    feedback += "\nERROR: Your bookmark must be between 0 and the number of pages in the book.";
                }
            }
        }
    }
}
