using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBook_Croteau
{
    public class Validator
    {
        static public bool GotBadWords(string temp)
        {
            bool result = false;

            string[] strBadWords = { "POOP", "HOMEWORK", "CACA" };

            temp = temp.ToUpper();

            foreach (string strBW in strBadWords)
                if (temp.Contains(strBW))
                {
                    result = true;
                }

            return result;
        }

        static public bool IsEmpty(string tString)
        {
            return (tString.Length == 0);
        }

        static public bool IsValidZip5(string temp)//only check validity of 5 char zip, not 5+4 zips
        {
            bool blnResult = true;


            if (temp.Length != 5)
            {
                blnResult = false;
            }

            foreach (char ch in temp)//ensures the characters provided for the zip are digits
                if (!Char.IsDigit(ch))
                {
                    blnResult = false;
                }

            return blnResult;
        }

        //recieves a string a checks to see if it has a semi-valid e-mail format
        static public bool IsValidEmail(string temp)
        {
            //assume it is true, make user prove it is false
            bool blnResult = true;

            //find the position of the @ 
            int atLocation = temp.IndexOf("@");
            //find out if there are more than one "@" in the address, if so, it isn't valid
            int nextAtLocation = temp.IndexOf("@", atLocation + 1);
            //find the location of the last period in the address
            int periodLocation = temp.LastIndexOf(".");

            //check for min length  -- this is based on a 1 @ 1 . 2 format for email
            if (temp.Length < 5)
            {
                blnResult = false;
            }

            else if (atLocation < 1) //verifies the @ is both present (not -1) and that there is at least one char in front of it
            {
                blnResult = false;
            }

            else if (nextAtLocation != -1)//verifies there is not a second "@" in the address
            {
                blnResult = false;
            }

            else if ((periodLocation - atLocation) < 1) //verifies at least 1 char between "@" and final "."
            {
                blnResult = false;
            }

            else if ((periodLocation + 2) > (temp.Length)) //verifies at least 2 char after the final "."
            {
                blnResult = false;
            }

            return blnResult;
        }

        static public bool IsValidPhone(string tString)
        {
            return (tString.Length == 10);
        }

        static public bool IsValidLength(string tString, int tLen)
        {
            return (tString.Length == tLen);
        }

        static public bool IsMinLength(string tString, int tMinLen)
        {
            return (tString.Length >= tMinLen);
        }

        static public bool IsMinValue(int tValue, int tMinVal)
        {
            return (tValue >= tMinVal);
        }

        static public bool IsMinValue(double tValue, double tMinVal)
        {
            return (tValue >= tMinVal);
        }

        static public bool IsMinValue(float tValue, float tMinVal)
        {
            return (tValue >= tMinVal);
        }

        static public bool IsFutureDate(DateTime temp)
        {
            bool blnResult;

            if (temp <= DateTime.Now)
            {
                blnResult = false;
            }

            else
            {
                blnResult = true;
            }

            return blnResult;
        }
    }
}
