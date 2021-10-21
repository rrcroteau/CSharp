//Ron Croteau
//SE245, Fall 2021
//Lab 3
/*
 * Program description: ***Convert Lab 2 to utilize Methods (Void, Return, By Ref). This program gets user input for a student's name and lab grades. The user can enter as many students as they want. Once user has input all student's names/grades, the student's average and letter grade, as well as class average for each lab, are calculted. All student's entered are then displayed with name, grades for each lab, average, and letter grade. The class average for each lab is then displayed.
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

        static void GetName(List<string> fName, List<string> lName)
        {
            ///Asks the user for first and last names and stores them to appropriate lists///

            Console.Write("Please enter the student's first name: ");
            fName.Add(Console.ReadLine());

            Console.Write("Please enter the student's last name: ");
            lName.Add(Console.ReadLine());
        }

        static void GetGrade(List<double> temp, int labNum)
        {
            ///This function prompts user for the grade for a specific lab, validates the grade, then adds it to the passed list ///

            //declare/initialize variables
            String strNum;
            Double dblNum;
            bool blnResult;

            //create do/while to validate lab grades
            do
            {
                //ask user for lab grade
                Console.Write($"Please enter the student's grade for Lab {labNum}: ");
                //store user input for validation
                strNum = Console.ReadLine();

                //validate if it is a proper double and not negative
                blnResult = Double.TryParse(strNum, out dblNum);

                if (blnResult == false || dblNum < 0)
                {
                    Console.WriteLine("\nInput Error - Please enter a positive number in digits: ex 92.5");
                }

            } while (blnResult == false || dblNum < 0);//keeps the user in the loop until they enter valid data (a positive number)

            //add the validated lab grade to the appropriate list
            temp.Add(dblNum);
        }
    
        static void AnotherStudent(ref String strAnswer)
        {
            ///Checks to see if user has another student to enter and validates the input///

            //create loop to see if user has another student to enter and ensure valid input
            do
            {
                //ask if user has another student to enter (loop control)
                Console.Write("\n\nDo you have another student to enter [y/n]: ");
                //store user input to variable in lower for loop condition
                strAnswer = Console.ReadLine().ToLower();

                if (strAnswer != "y" && strAnswer != "n")//ensures user only entered a 'y' or 'n' (case insensitive due to ToLower above)
                {
                    Console.WriteLine("Input Error - Please enter only a 'y' or 'n'");
                }

            } while (strAnswer != "y" && strAnswer != "n");//keeps user in loop until valid input entered

        }

        static void StudentAvgCalc(List<double> lab1, List<double> lab2, List<double> lab3, List<double> lab4, List<double> lab5, List<double> studentAvg)
        {
            ///Calculates the student's average for all 5 labs and stores it into the relevant list///

            double dblAvg;

            for (int i = 0; i < lab1.Count(); i++)
            {
                //calculate each students average from all labs and store in relevant list
                dblAvg = (lab1[i] + lab2[i] + lab3[i] + lab4[i] + lab5[i]) / 5;
                studentAvg.Add(dblAvg);
            }
        }

        static void LetterGradeCalc(List<double> studentAvg, List<string> ltrGrade)
        {
            ///Calculates the letter grade based on the student's average///

            for (int i = 0; i < studentAvg.Count(); i++)
            {

                //determine letter grade based on student average and store in relevant list
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
            }
        }

        static double LabTotals(List<double> lab, double total)
        {
            ///Adds the grades for a given lab into a totaling variable, used to later get averages///

            foreach (double grade in lab)

                total += grade;

            return total;
        }

        static void DisplayStudentData(List<string> fName, List<string> lName, List<double> lab1, List<double> lab2, List<double> lab3, List<double> lab4, List<double> lab5, List<double> studentAvg, List<string> ltrGrade)
        {
            ///Displays all of the data for each individual student///

            for (int i = 0; i < fName.Count(); i++)
            {
                Console.WriteLine($"\n{fName[i]} {lName[i]}");
                Console.WriteLine($"Lab 1: {lab1[i]} Lab 2: {lab2[i]} Lab 3: {lab3[i]} Lab 4: {lab4[i]} Lab 5: {lab5[i]}");
                Console.WriteLine($"Student Average: {studentAvg[i]} Letter Grade: {ltrGrade[i]}\n");
            }
        }

        static double LabAvgCalc(double labTotal, int counter)
        {
            ///Takes the total of a lab and the counter for the lab then calculates and returns the average, rounded to 2nd decimal///

            //declare temp var
            double tempAvg;
            //calculate the average for the lab and round to 2nd decimal
            tempAvg = Math.Round(labTotal / counter, 2);

            return tempAvg;
        }

        static void Pause()
        {
            ///Pauses the console so that the user can view the information prior to the application continuing or closing///

            Console.WriteLine("\n\nPress any key to exit . . .");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            //declare/initialize variables
            Int32 intCntr;
            String strAnswer = "";
            Double dblLab1Total = 0, dblLab2Total = 0, dblLab3Total = 0, dblLab4Total = 0, dblLab5Total = 0, dblLab1Avg, dblLab2Avg, dblLab3Avg, dblLab4Avg, dblLab5Avg;

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
                //ask user for data and store to relevant list
                GetName(fName, lName);

                //get grades for all 5 labs using the GetGrade function
                GetGrade(lab1, 1);
                GetGrade(lab2, 2);
                GetGrade(lab3, 3);
                GetGrade(lab4, 4);
                GetGrade(lab5, 5);

                //see if the user wants to enter another student
                AnotherStudent(ref strAnswer);

            } while (strAnswer == "y");

            //store number of records entered into variable for use in FOR loop
            intCntr = lab1.Count();

            //calculate student averages
            StudentAvgCalc(lab1, lab2, lab3, lab4, lab5, studentAvg);
            
            //calculate letter grades
            LetterGradeCalc(studentAvg, ltrGrade);

            //calculate the lab totals for each lab (to get averages later)
            dblLab1Total = LabTotals(lab1, dblLab1Total);
            dblLab2Total = LabTotals(lab2, dblLab2Total);
            dblLab3Total = LabTotals(lab3, dblLab3Total);
            dblLab4Total = LabTotals(lab4, dblLab4Total);
            dblLab5Total = LabTotals(lab5, dblLab5Total);

            //display the information for each student's data
            DisplayStudentData(fName, lName, lab1, lab2, lab3, lab4, lab5, studentAvg, ltrGrade);
            
            //calculate the average for each lab
            dblLab1Avg = LabAvgCalc(dblLab1Total, intCntr);
            dblLab2Avg = LabAvgCalc(dblLab2Total, intCntr);
            dblLab3Avg = LabAvgCalc(dblLab3Total, intCntr);
            dblLab4Avg = LabAvgCalc(dblLab4Total, intCntr);
            dblLab5Avg = LabAvgCalc(dblLab5Total, intCntr);

            //display the averages for each lab
            Console.WriteLine("\nClass Averages for Each Lab");
            Console.WriteLine($"Lab 1: {dblLab1Avg} Lab 2: {dblLab2Avg} Lab 3: {dblLab3Avg} Lab 4: {dblLab4Avg} Lab 5: {dblLab5Avg}");

            //Pause the console so that the user can view the information prior to the application closing
            Pause();
        }
    }
}
