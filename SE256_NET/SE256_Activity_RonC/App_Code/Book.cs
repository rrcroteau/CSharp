using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE256_Activity_RonC.App_Code
{
    public class Book
    {
        private string title;
        private string authFName;
        private string authLName;
        private string email;
        private DateTime datePublished;
        private int pages;
        private double price;

        protected string feedback; //protected, so only children can see it

        public string Title
        {
            get { return title; }
            set
            {
                if (!Validator.IsEmpty(value) && !Validator.GotBadWords(value))
                {
                    title = value;
                }

                else
                {
                    feedback += "\nERROR: Please enter a valid Title, this field cannot be empty or have bad words.";
                }
            }
        }

        public string AuthFName
        {
            get { return authFName; }
            set
            {
                if (!Validator.GotBadWords(value))
                {
                    authFName = value;
                }

                else
                {
                    feedback += "\nERROR: This author's name cannot have bad words.";
                }
            }
        }

        public string AuthLName
        {
            get { return authLName; }
            set
            {
                if (!Validator.GotBadWords(value))
                {
                    authLName = value;
                }

                else
                {
                    feedback += "\nERROR: This author's name cannot have bad words.";
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (Validator.IsValidEmail(value))
                {
                    email = value;
                }
                else
                {
                    feedback += "\nERROR: Please enter a valid Email address.";
                }
            }
        }

        public DateTime DatePublished
        {
            get { return datePublished; }
            set
            {
                if (!Validator.IsFutureDate(value))
                {
                    datePublished = value;
                }
                else
                {
                    feedback += "\nERROR: You cannot enter future dates for the date published.";
                }
            }
        }

        public int Pages
        {
            get { return pages; }
            set
            {
                if (Validator.IsMinValue(value, 1))
                {
                    pages = value;
                }

                else
                {
                    feedback += "\nERROR: Sorry, you entered an invalid number of pages.";
                }
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (Validator.IsMinValue(value, 1))
                {
                    price = value;
                }
                else
                {
                    feedback += "\nERROR: Sorry, you entered an invalid price.";
                }
            }
        }

        public string Feedback
        {
            get { return feedback; }
            //set { feedback = value; } does not need a SET as it is a protected variable and thereby accessible by derived classes
        }

        //Create constructor to initialize variables (so they are not NULL)
        public Book()
        {
            title = "";
            authFName = "";
            authLName = "";
            pages = 0;
            datePublished = DateTime.Parse("1/1/1500");
            price = 0.0;
            feedback = "";
        }

    }
}