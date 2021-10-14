//Ron Croteau
//SE245, Fall 2021
//Lab 2
/*
 * Program description: This program gets a students name and grades for 5 labs. It can take data from more than 1 student.
 * It displays each student with each average grade for their 5 labs, and their letter grade.  
 * It then displays the average for each lab #.  (Average grade on Lab #1 for all students)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab2_Croteau
{
    class Program
    {

        static void GetGrade(List<double> temp, int labNum)
        {
            ///This function takes a list and int representing which grade you want to update. It prompts user for the grade for a specific lab, validates the grade, then adds it to the passed list ///
            
            //declare/initialize variables
            String strNum;
            Double dblNum;
            bool blnResult = false;

            //create do/while to validate lab grades
            do
            {
                //ask user for lab grade
                Console.Write($"Please enter the student's grade for Lab {labNum}: ");
                //store user input for validation
                strNum = Console.ReadLine();

                //validate if it is a proper double
                blnResult = Double.TryParse(strNum, out dblNum);

                if (blnResult == false || dblNum < 0)
                {
                    Console.WriteLine("\n\nInvalid Input: Please enter a positive real number in digits: ex 92.5");
                }

            } while (blnResult == false);

            //add the validated lab grade to the appropriate list
            temp.Add(dblNum);
        }

        static void Main(string[] args)
        {
            //declare/initialize variables
            String strAnswer;
            Double dblAvg, dblLab1Total = 0, dblLab2Total = 0, dblLab3Total = 0, dblLab4Total = 0, dblLab5Total = 0;
            
            //create lists to store data
            List<string> fName = new List<string>();
            List<string> lName = new List<string>();
            List<string> ltrGrade = new List<string>();
            List<double> lab1 = new List<double>();
            List<double> lab2 = new List<double>();
            List<double> lab3 = new List<double>();
            List<double> lab4 = new List<double>();
            List<double> lab5 = new List<double>();
            List<double> studentAvg = new List<double>();

            //create loop to solicit data from user
            do
            {
                //ask user for first name
                Console.Write("Please enter the student's first name: ");
                //store user input to appropriate list
                fName.Add(Console.ReadLine());

                //ask user for last name
                Console.Write("Please enter the student's last name: ");
                //store user input to appropriate list
                lName.Add(Console.ReadLine());

                //get grades for all 5 labs using the GetGrade function
                GetGrade(lab1, 1);
                GetGrade(lab2, 2);
                GetGrade(lab3, 3);
                GetGrade(lab4, 4);
                GetGrade(lab5, 5);

                //ask if user has another student to enter (loop control)
                Console.Write("\n\nDo you have another student to enter [y/n]: ");
                //store user input to variable in lower for loop condition
                strAnswer = Console.ReadLine().ToLower();
                

            } while (strAnswer == "y");


            //determine the average for each student using a for loop based on the number of entries in the list ( list.Count())
            for (int i = 0; i < lab1.Count(); i++ )
            {
                dblAvg = (lab1[i] + lab2[i] + lab3[i] + lab4[i] + lab5[i]) / 5;
                studentAvg.Add(dblAvg);
                
            }

            //determine the letter grade based on the average using a for loop and add it to letter grade list
            for (int i = 0; i < studentAvg.Count(); i++)

                if (studentAvg[i] >= 90)
                {
                    ltrGrade.Add("A");
                }

                else if (studentAvg[i] >= 80)
                {
                    ltrGrade.Add("B");
                }

                else if (studentAvg[i] >= 70)
                {
                    ltrGrade.Add("C");
                }

                else if (studentAvg[i] >= 60)
                {
                    ltrGrade.Add("D");
                }

                else
                {
                    ltrGrade.Add("F");
                }



            //display the information for each student's data using a for loop
            for (int i = 0; i < fName.Count(); i++)
            {
                Console.WriteLine($"{fName[i]} {lName[i]}");
                Console.WriteLine($"Lab 1: {lab1[i]} Lab 2: {lab2[i]} Lab 3: {lab3[i]} Lab 4: {lab4[i]} Lab 5: {lab5[i]}");
                Console.WriteLine($"Student Average: {studentAvg[i]} Letter Grade: {ltrGrade[i]}\n\n");
            }

            //calculate the total of all grades from each lab to be used for averages
            for (int i = 0; i < lab1.Count(); i++)
            {
                dblLab1Total += lab1[i];
                dblLab2Total += lab2[i];
                dblLab3Total += lab3[i];
                dblLab4Total += lab4[i];
                dblLab5Total += lab5[i];
            }

            //display the averages for each lab rounded to the 2nd decimal
            Console.WriteLine("\nAverages for Each Lab");
            Console.WriteLine($"Lab 1: {Math.Round(dblLab1Total / lab1.Count(), 2)} Lab 2: {Math.Round(dblLab2Total / lab2.Count(), 2)} Lab 3: {Math.Round(dblLab3Total / lab3.Count(), 2)} Lab 4: {Math.Round(dblLab4Total / lab4.Count(), 2)} Lab 5: {Math.Round(dblLab5Total / lab5.Count(),2 )}");

            //Pause the console so that the user can view the information prior to the application closing
            Console.WriteLine("\n\nPress any key to exit . . .");
            Console.ReadKey();
        }
    }
}
