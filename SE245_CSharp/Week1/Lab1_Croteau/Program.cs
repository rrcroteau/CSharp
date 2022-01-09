//Ron Croteau
//SE245, Fall 2021
//Lab 1
/*
 * Program description: This program takes the name of a student and then the four grades the student earned. 
 * It finds the average of the four grades and then assigns and outputs a letter grade based on the average.
 * For extra credit(bonus), the program also uses a weighted grade system based on 20%, 20%, 25%, 35% in order to determine the weighted average and letter grade and outputs the information to the user.
 */

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
            Double dblGrade1, dblGrade2, dblGrade3, dblGrade4, dblAvg, dblWeightedGrade1, dblWeightedGrade2, dblWeightedGrade3, dblWeightedGrade4, dblWeightedAvg;

            //print to the console
            Console.WriteLine("Hello There!");

            //print to the console w/o new line
            Console.Write("Please enter the student's name: ");
            //store user input to variable
            strName = Console.ReadLine();

            //solicit the four grades to be used in determining the average
            Console.Write($"Please enter the first grade for {strName}: ");
            strGrade1 = Console.ReadLine();

            Console.Write($"Please enter the second grade for {strName}: ");
            strGrade2 = Console.ReadLine();

            Console.Write($"Please enter the third grade for {strName}: ");
            strGrade3 = Console.ReadLine();

            Console.Write($"Please enter the fourth grade for {strName}: ");
            strGrade4 = Console.ReadLine();

            //convert the string numbers to doubles to be used in math operations
            dblGrade1 = Double.Parse(strGrade1);
            dblGrade2 = Double.Parse(strGrade2);
            dblGrade3 = Double.Parse(strGrade3);
            dblGrade4 = Double.Parse(strGrade4);

            //determine the avg given the four grades entered
            dblAvg = (dblGrade1 + dblGrade2 + dblGrade3 + dblGrade4) / 4;

            //for extra credit, get the weighted grades by applying a weighted percentage for the four scores (20%, 20%, 25%, 35%, respectively)
            dblWeightedGrade1 = dblGrade1 * .2;
            dblWeightedGrade2 = dblGrade2 * .2;
            dblWeightedGrade3 = dblGrade3 * .25;
            dblWeightedGrade4 = dblGrade4 * .35;

            //considering these are weighted grades, you simply need to add them to get the weighted average (as the percentages add up to 100%)
            dblWeightedAvg = dblWeightedGrade1 + dblWeightedGrade2 + dblWeightedGrade3 + dblWeightedGrade4;

            //figure out the letter grade based on raw scores/average and output to user
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

            //for extra credit, figure out the weighted letter grade based on weighted scores/average and output to user
            if (dblWeightedAvg >= 90)
            {
                Console.WriteLine($"\n\n{strName} has a weighted average of {dblWeightedAvg} for a weighted letter grade of A.");
            }

            else if (dblWeightedAvg >= 80)
            {
                Console.WriteLine($"\n\n{strName} has a weighted average of {dblWeightedAvg} for a weighted letter grade of B.");
            }

            else if (dblWeightedAvg >= 70)
            {
                Console.WriteLine($"\n\n{strName} has a weighted average of {dblWeightedAvg} for a weighted letter grade of C.");
            }

            else if (dblWeightedAvg >= 60)
            {
                Console.WriteLine($"\n\n{strName} has a weighted average of {dblWeightedAvg} for a weighted letter grade of D.");
            }

            else
            {
                Console.WriteLine($"\n\n{strName} has a weighted average of {dblWeightedAvg} for a weighted letter grade of F.");
            }

            //Pause the console so that the user can view the information prior to the application closing
            Console.WriteLine("\n\nPress any key to continue . . .");
            Console.ReadKey();
        }
    }
}
