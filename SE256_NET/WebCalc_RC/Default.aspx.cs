using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCalc_RC
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //One event method to handle multiple button-clicks
        //It will use the text stored to the button to determine the value to append to the string in the 'LCD display'
        protected void NumButtons_Click(object sender, EventArgs e)
        {
            //check to see if Equals was last pressed (check the operand label ) and if so, clear the display and reset the operand label
            if (lblOperand.Text == "=")
            {
                txtLCD.Text = "";
                lblOperand.Text = "";
            }

            //create this temp button in order to record the Text (in this case, the number) associated with the button
            Button temp = (Button)sender;

            txtLCD.Text += temp.Text;

            //now that there is something to be cleared from the display, changed the clear button from AC (All Clear) to CE (Clear Entry)
            btnClear.Text = "CE";
        }

        //One event method to handle multiple button-clicks
        //It will use the text stored to the button to determine the operand to store

        protected void Operand_Click(object sender, EventArgs e)
        {
            
            //to avoid errors, lets make sure there are some numbers in the display before we try to store them
            if (txtLCD.Text != "")
            {   //You must store what is currently in the display in order use it later in the mathematical operation. You must use Session variables as tradition vars are deleted on refresh
                //The session variables are only available to the user browser and is available for 20 mins since last activity (by default)

                Session["Num1"] = txtLCD.Text; //this takes what is in the display and saves it as a session variable

                //create this temp button in order to record the Text (in this case, the operand) associated with the button
                Button temp = (Button)sender;

                //store the operand selected to a session variable to be used when we press the Equals (=) button
                Session["Operand"] = temp.Text;

                //update the previous operand used label to the right of the LCD
                lblOperand.Text = temp.Text;

                //Clear the 'LCD Display' so the user can type in the next value
                txtLCD.Text = "";            

            }

            
        }

        protected void Equals_Click(object sender, EventArgs e)
        {
            //to avoid errors we must first check that a session variable has been set for Num1 and that some numbers are current in the display
            if (Session["Num1"] != null && txtLCD.Text != "")
            {
                //First we must store the current number in the display (we must also parse the numbers (currently strings) so we can do math with them
                Double Num2 = Double.Parse(txtLCD.Text); //these can be local variables because the will only be used in the session which calculates/displays the result
                Double Num1 = Double.Parse(Session["Num1"].ToString()); //retrieve Num1 we stored as session var earlier, set to string, parse to double, then store
                String Operand = Session["Operand"].ToString(); //retrieve the operand we stored as a session var to use in the math computation control flow in this function
                Double Result = 0; //create a variable to hold the mathematical result

                //We must decide which math to perform based on the operand stored and the stored number(s)
                switch (Operand)
                {

                    case "+":
                        Result = Num1 + Num2;
                        break;

                    case "-":
                        Result = Num1 - Num2;
                        break;

                    case "x":
                        Result = Num1 * Num2;
                        break;

                    case "/":
                        Result = Num1 / Num2;
                        break;
                }

                //We must then display the results to the user
                txtLCD.Text = Result.ToString();

                //we also change the operand label
                lblOperand.Text = "=";
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {

            //make the button inactive if there is nothing stored to the session variable and nothing in the LCD
            if (btnClear.Text == "AC" && txtLCD.Text == "" && Session["Num1"] == null)
            {
                btnClear.Enabled = false;
            }

            else
            {
                btnClear.Enabled = true;
            }


            //if the button is set to AC, this will clear anything stored to the session variable of Num1 and "hard reset" the functions of the calculator, if not it will just clear the current entry on the screen
            if (btnClear.Text == "AC")
            {
                Session["Num1"] = null;
            }
            
            txtLCD.Text = ""; //simply clears out the LCD
            lblOperand.Text = ""; //also clears the operand label

            //reset the button to AC (all clear) once the display empty
            btnClear.Text = "AC";
        }

        protected void NegPos_Click(object sender, EventArgs e)
        {
            if (txtLCD.Text != "")
            {
                //this button will make a positive number negative and vice versa
                if (Double.Parse(txtLCD.Text) > 0)
                {
                    txtLCD.Text = "-" + txtLCD.Text;
                }
                else
                {
                    txtLCD.Text = txtLCD.Text.Remove(0, 1); //if there is a negative in the zeroeth index, it will remove it from the string
                }
            }
        }

        protected void Percent_Click(object sender, EventArgs e)
        {
            //this button determines the percent a number is (basically divides it by 100)
            txtLCD.Text = (Double.Parse(txtLCD.Text) / 100).ToString();  //takes the current value in LCD, parses to double, divides by 100, then sets back to string to store back in LCD
        }

        protected void MemoryStore_Click(object sender, EventArgs e)
        {
            Session["Memory"] = txtLCD.Text; //this takes what is in the display and saves it as a session variable representing the Memory

            lblMemory.Text = "M";
        }

        protected void MemoryRestore_Click(object sender, EventArgs e)
        {

            txtLCD.Text = Session["Memory"].ToString();
        }

        protected void MemoryClear_Click(object sender, EventArgs e)
        {
            Session["Memory"] = "";
            lblMemory.Text = "";
        }
    }
}