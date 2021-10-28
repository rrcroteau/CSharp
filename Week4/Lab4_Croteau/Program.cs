using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ron Croteau
//SE245, Fall 2021
//Lab 4
/*
 * Program description: Create a person class that holds common data about a person. Solicit the data from the user about a person, then display it to the console.
 */

namespace Lab4_Croteau
{
    class Program
    {
        //create a structure to hold a person's information
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

            //get and set all the class variables
            public string FName
            {
                get
                {
                    return fName;
                }

                set
                {
                    fName = value;
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
                    lName = value;
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
                    street1 = value;
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
                    city = value;
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
                    state = value;
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
                    zip = value;
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
                    phone = value;
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
                    email = value;
                }
            }
        }

        static void Main(string[] args)
        {

            //create a person
            Person temp = new Person();

            //get data to fill person
            Console.Write("Please enter the person's first name: ");
            temp.FName = Console.ReadLine();

            Console.Write("Please enter the person's middle name: ");
            temp.MName = Console.ReadLine();

            Console.Write("Please enter the person's last name: ");
            temp.LName = Console.ReadLine();

            Console.Write("Please enter the person's street address (Line 1): ");
            temp.Street1 = Console.ReadLine();

            Console.Write("Please enter the person's street address (Line 2, if applicable): ");
            temp.Street2 = Console.ReadLine();

            Console.Write("Please enter the person's city: ");
            temp.City = Console.ReadLine();

            Console.Write("Please enter the person's state: ");
            temp.State = Console.ReadLine();

            Console.Write("Please enter the person's zip: ");
            temp.Zip = Console.ReadLine();

            Console.Write("Please enter the person's phone number: ");
            temp.Phone = Console.ReadLine();

            Console.Write("Please enter the person's email address: ");
            temp.Email = Console.ReadLine();

            temp.FName += "poopy";

            //output person data
            Console.WriteLine($"New Member: {temp.FName} {temp.MName} {temp.LName}");
            Console.WriteLine($"            {temp.Street1}");

            //only display street2 if it isn't blank
            if (temp.Street2 != "")
            {
                Console.WriteLine($"            {temp.Street2}");
            }

            Console.WriteLine($"            {temp.City}, {temp.State}  {temp.Zip}");
            Console.WriteLine($"            {temp.Phone} | {temp.Email}");

            //let user decide when to end the program (pause the output before closing)
            BasicTools.Pause();
        }
    }
}
