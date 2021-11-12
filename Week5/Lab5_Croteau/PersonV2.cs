using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Croteau
{
    public class PersonV2 : Person  //inherit from Person class
    {
        private string cellPhone;
        private string instagramURL;


        //create a constructor for the PersonV2 class
        public PersonV2() : base()
        {
            cellPhone = "";
            instagramURL = "";

        }

        public string CellPhone
        {
            get { return cellPhone; }

            set
            {
                //needs to be a 10 digits
                if (Validator.IsValidPhone(value))
                {
                    cellPhone = value; //store it
                }

                else
                {
                    //invalid phone number, give error message
                    Feedback += "ERROR: Please enter a 10 digit phone number including area code (i.e. 5551236789).\n";
                }
            }
        }

        public string InstagramURL
        {
            get
            {
                return instagramURL;
            }

            set
            {
                if (!Validator.GotBadWords(value))
                {
                    instagramURL = value;
                }

                else
                {
                    Feedback += "ERROR: The Instagram URL cannot contain prohibited words.\n";
                }
            }
        }
    }
}
