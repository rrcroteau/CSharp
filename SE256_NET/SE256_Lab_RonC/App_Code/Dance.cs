using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE256_Lab_RonC.App_Code
{
    public class Dance
    {
        private string danceName;
        private string choreo1FName;
        private string choreo1LName;
        private string choreo2FName;
        private string choreo2LName;
        private string choreo3FName;
        private string choreo3LName;
        private string music;
        private string artist;
        private string lineOrPartner;
        private string difficulty;
        private int dance_ID;
        private int steps;
        private int walls;
        private DateTime dateChoreo;

        protected string feedback; //protected, so only children can see it


        #pragma warning disable 0436 //this is to get rid of the type conflict error with the Validator 
        public string DanceName
        {
            get { return danceName; }
            set
            {
                if (!Validator.IsEmpty(value) && !Validator.GotBadWords(value))
                {
                    danceName = value;
                }

                else
                {
                    feedback += "\nERROR: Please enter a valid Dance, this field cannot be empty or have bad words.";
                }
            }
        }

        public string Choreo1FName
        {
            get { return choreo1FName; }
            set
            {
                if (!Validator.IsEmpty(value) && !Validator.GotBadWords(value))
                {
                    choreo1FName = value;
                }

                else
                {
                    feedback += "\nERROR: The choreographers's first name cannot be empty or have bad words.";
                }
            }
        }

        public string Choreo1LName
        {
            get { return choreo1LName; }
            set
            {
                if (!Validator.IsEmpty(value) && !Validator.GotBadWords(value))
                {
                    choreo1LName = value;
                }

                else
                {
                    feedback += "\nERROR: The choreographers's last name cannot be empty or have bad words.";
                }
            }
        }

        public string Choreo2FName
        {
            get { return choreo2FName; }
            set
            {
                if (!Validator.GotBadWords(value))
                {
                    choreo2FName = value;
                }

                else
                {
                    feedback += "\nERROR: The choreographers's first name cannot have bad words.";
                }
            }
        }

        public string Choreo2LName
        {
            get { return choreo2LName; }
            set
            {
                if (!Validator.GotBadWords(value))
                {
                    choreo2LName = value;
                }

                else
                {
                    feedback += "\nERROR: The choreographers's last name cannot have bad words.";
                }
            }
        }

        public string Choreo3FName
        {
            get { return choreo3FName; }
            set
            {
                if (!Validator.GotBadWords(value))
                {
                    choreo3FName = value;
                }

                else
                {
                    feedback += "\nERROR: The choreographers's first name cannot have bad words.";
                }
            }
        }

        public string Choreo3LName
        {
            get { return choreo3LName; }
            set
            {
                if (!Validator.GotBadWords(value))
                {
                    choreo3LName = value;
                }

                else
                {
                    feedback += "\nERROR: The choreographers's last name cannot have bad words.";
                }
            }
        }

        public string Music
        {
            get { return music; }
            set
            {
                if (!Validator.IsEmpty(value) && !Validator.GotBadWords(value))
                {
                    music = value;
                }
                else
                {
                    feedback += "\nERROR: The music field cannot be empty or have bad words";
                }
            }
        }

        public string Artist
        {
            get { return artist; }
            set
            {
                if (!Validator.IsEmpty(value) && !Validator.GotBadWords(value))
                {
                    artist = value;
                }
                else
                {
                    feedback += "\nERROR: The artist field cannot be empty of have bad words.";
                }
            }
        }

        public string LineOrPartner
        {
            get { return lineOrPartner; }

            set
            {
                if (!Validator.IsEmpty(value))
                {
                    lineOrPartner = value;
                }

                else
                {
                    feedback += "\nERROR: There must be a selection made for line or partner style.";
                }
            }
        }

        public string Difficulty
        {
            get { return difficulty; }

            set
            {
                if (!Validator.IsEmpty(value))
                {
                    difficulty = value;
                }

                else
                {
                    feedback += "\nERROR: The difficulty field cannot be left empty.";
                }
            }
        }

        public int Dance_ID
        {
            get { return dance_ID; }

            set
            {
                if (value >= 0)
                {
                    dance_ID = value;  //store the ID
                }
                else
                {
                    //Store an error msg in Feedback
                    feedback += "\nERROR: Sorry you entered an invalid Dance ID.";
                }
            }
        }

        public int Steps
        {
            get { return steps; }
            set
            {
                if (Validator.IsMinValue(value, 8))
                {
                    steps = value;
                }

                else
                {
                    feedback += "\nERROR: Please enter the step count (at least 8 counts).";
                }
            }
        }

        public int Walls
        {
            get { return walls; }
            set
            {
                if (value > 0 && value <5)
                {
                    walls = value;
                }
                else
                {
                    feedback += "\nERROR: Please enter number of walls between 1 and 4";
                }
            }
        }

        public DateTime DateChoreo
        {
            get { return dateChoreo; }
            set
            {
                if (!Validator.IsFutureDate(value))
                {
                    dateChoreo = value;
                }
                else
                {
                    feedback += "\nERROR: Please enter the date choreographed. It cannot be a future date.";
                }
            }
        }

        public string Feedback
        {
            get { return feedback; }
            //set { feedback = value; } does not need a SET as it is a protected variable and thereby accessible by derived classes
        }

        //Create constructor to initialize variables(so they are not NULL)
        public Dance()
        {

            danceName = "";
            choreo1FName = "";
            choreo1LName = "";
            music = "";
            artist = "";
            difficulty = "";
            steps = 8;
            walls = 4;
            dateChoreo = DateTime.Parse("1/1/2045");
            feedback = "";
        }

    }
}

