using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Croteau
{
    public class Person
    {
        private string fName; //first name
        private string mName; //middle name
        private string lName; //last name
        private string street1;
        private string street2;
        private string city;
        private string state;
        private string zip;
        private string phone;
        private string email;
        public string Feedback;

        //create a constructor for the Person class
        public Person()
        {
            fName = "";
            mName = "";
            lName = "";
            street1 = "";
            street2 = "";
            city = "";
            state = "";
            zip = "";
            phone = "";
            email = "";
            Feedback = "";
        }

        //get and set all the class variables
        public string FName
        {
            get
            {
                return fName;
            }

            set
            {
                if (Validator.IsMinLength(value, 1))
                {
                    fName = value;
                }
                else 
                {
                    Feedback += "ERROR: Please enter at least one character for the First Name.\n";
                }
            }
        }

        public string MName
        {
            get
            {
                return mName;
            }

            set
            {
                mName = value;
            }
        }

        public string LName
        {
            get
            {
                return lName;
            }

            set
            {
                if (Validator.IsMinLength(value, 1))
                {
                    lName = value;
                }
                else
                {
                    Feedback += "ERROR: Please enter at least one character for the Last Name.\n";
                }
            }
        }

        public string Street1
        {
            get
            {
                return street1;
            }

            set
            {
                if (Validator.IsMinLength(value, 1))
                {
                    street1 = value;
                }
                else
                {
                    Feedback += "ERROR: Please enter at least one character for the Street.\n";
                }
            }
        }

        public string Street2
        {
            get
            {
                return street2;
            }

            set
            {
                street2 = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                if (Validator.IsMinLength(value, 1))
                {
                    city = value;
                }
                else
                {
                    Feedback += "ERROR: Please enter at least one character for the City.\n";
                }
            }
        }

        public string State
        {
            get
            {
                return state;
            }

            set
            {
                if (Validator.IsMinLength(value, 2))
                {
                    state = value;
                }
                else
                {
                    Feedback += "ERROR: Please enter at least a two character abbreviation for the State (i.e. RI).\n";
                }
            }
        }

        public string Zip
        {
            get
            {
                return zip;
            }

            set
            {
                if (Validator.IsMinLength(value, 5))
                {
                    zip = value;
                }
                else
                {
                    Feedback += "ERROR: Please enter a 5 digit zip code (i.e. 02895).\n";
                }
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                if (Validator.IsMinLength(value, 10))
                {
                    phone = value;
                }
                else
                {
                    Feedback += "ERROR: Please enter a 10 digit phone number including area code (i.e. 5551236789).\n";
                }
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                if (Validator.IsMinLength(value, 8))
                {
                    email = value;
                }
                else
                {
                    Feedback += "ERROR: Please enter a valid email address (i.e. name@mail.com).\n";
                }
            }
        }
    }
}
