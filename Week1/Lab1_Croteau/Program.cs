using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Croteau
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare/initialize variables
            String strName, strGrade1, strGrade2, strGrade3, strGrade4;
            Double dblGrade1, dblGrade2, dblGrade3, dblGrade4, dblAvg = 0;

            //print to the console
            Console.WriteLine("Hello There!");

            //print to the console w/o new line
            Console.Write("Please the student's name: ");
            //store user input to variable
            strName = Console.ReadLine();

            Console.WriteLine($"Please enter the first grade for {strName}: ");
            strGrade1 = Console.ReadLine();

            Console.WriteLine($"Please enter the second grade for {strName}: ");
            strGrade2 = Console.ReadLine();

            Console.WriteLine($"Please enter the third grade for {strName}: ");
            strGrade3 = Console.ReadLine();

            Console.WriteLine($"Please enter the fourth grade for {strName}: ");
            strGrade4 = Console.ReadLine();

            //convert the string numbers to doubles to be used in math operations
            dblGrade1 = Double.Parse(strGrade1);
            dblGrade2 = Double.Parse(strGrade2);
            dblGrade3 = Double.Parse(strGrade3);
            dblGrade4 = Double.Parse(strGrade4);

            //determine the avg given the four grades entered
            dblAvg = (dblGrade1 + dblGrade2 + dblGrade3 + dblGrade4) / 4; 

            if (dblAvg >= 90)
            {
                Console.WriteLine($"\n\n{strName} has an average of {dblAvg} for a letter grade of A.");
            }

            else if (dblAvg >= 80)
            {
                Console.WriteLine($"\n\n{strName} has an average of {dblAvg} for a letter grade of B.");
            }

            else if (dblAvg >= 70)
            {
                Console.WriteLine($"\n\n{strName} has an average of {dblAvg} for a letter grade of C.");
            }

            else if (dblAvg >= 60)
            {
                Console.WriteLine($"\n\n{strName} has an average of {dblAvg} for a letter grade of D.");
            }

            else
            {
                Console.WriteLine($"\n\n{strName} has an average of {dblAvg} for a letter grade of F.");
            }

            //Pause the console so that the user can view the information prior to the application closing
            Console.WriteLine("\n\nPress any key to continue . . .");
            Console.ReadKey();
        }
    }
}
