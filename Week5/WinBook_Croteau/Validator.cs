using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBook_Croteau
{
    public class Validator
    {
        static public bool IsEmpty(string tString)
        {
            return (tString.Length == 0);
        }

        static public bool IsValidZip(string tString)
        {
            return (tString.Length == 5);
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
    }
}
