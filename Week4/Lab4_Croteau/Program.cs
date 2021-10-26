using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Croteau
{
    class Program
    {
        //create a structure to hold a person's information
        struct Person
        {
            public string FName; //first name
            public string MName; //middle name
            public string LName; //last name
            public string Street1; 
            public string Street2;
            public string City;
            public string State;
            public string Zip;
            public string Phone;
            public string Email;
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



            //output person data
            Console.WriteLine($"New Member: {temp.FName} {temp.MName} {temp.LName}");

            //let user decide when to end the program (pause the output before closing)
            BasicTools.Pause();
        }
    }
}
