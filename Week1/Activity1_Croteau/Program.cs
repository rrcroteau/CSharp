using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity1_Croteau
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare/initialize variables
            String strFirst, strOperand, strNum1, strNum2;
            Double dblNum1, dblNum2, dblResult = 0;

            //print to the console
            Console.WriteLine("Hello There!");

            //print to the console w/o new line
            Console.Write("Please enter your first name: ");
            //store user input to variable in the title case
            strFirst = Console.ReadLine();

            //create and output a custom message to the user with their name via concatenation
            Console.WriteLine("Hello " + strFirst + "! Let's do some math!");

            Console.WriteLine("Please enter the first number: ");
            strNum1 = Console.ReadLine();

            Console.WriteLine("Please enter the math operation (PLUS, MINUS, MULTIPLY, DIVIDE): ");
            strOperand = Console.ReadLine().ToUpper();//cast this to upper to ensure the switch/case below works

            Console.WriteLine("Please enter the second number: ");
            strNum2 = Console.ReadLine();

            //convert the string numbers to doubles to be using in math operations
            dblNum1 = Double.Parse(strNum1);
            dblNum2 = Double.Parse(strNum2);

            //use switch case to determine what math operation to use based on user input
            switch(strOperand)
            {
                case "PLUS":
                    //use addition
                    dblResult = dblNum1 + dblNum2;
                    break;

                case "MINUS":
                    //use subtractions
                    dblResult = dblNum1 - dblNum2;
                    break;

                case "MULTIPLY":
                    //use multiplication
                    dblResult = dblNum1 * dblNum2;
                    break;

                case "DIVIDE":
                    //use division
                    dblResult = dblNum1 / dblNum2;
                    break;

                default:
                    //user did not use an appropriate math operation
                    Console.WriteLine("I am sorry, I do not recognize what math operation you wanted to use. Please verify your spelling next time");
                    break;
            }

            if (strOperand == "PLUS")
            {
                Console.WriteLine($"\n\nThe sum of {dblNum1} and {dblNum2} equals: {dblResult}.");
            }

            else if (strOperand == "MINUS")
            {
                Console.WriteLine($"\n\nThe difference of {dblNum1} and {dblNum2} equals: {dblResult}.");
            }

            else if (strOperand == "MULTIPLY")
            {
                Console.WriteLine($"\n\nThe product of {dblNum1} and {dblNum2} equals: {dblResult}.");
            }

            else if (strOperand == "DIVIDE")
            {
                Console.WriteLine($"\n\nThe quotient of {dblNum1} and {dblNum2} equals: {dblResult}.");
            }

            //Pause the console so that the user can view the information prior to the application closing
            Console.WriteLine("\n\nPress any key to continue . . .");
            Console.ReadKey();



        }
    }
}
