using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Use these namespaces to include DB capabilities for generic components and SQL Server
using System.Data;
using System.Data.SqlClient;

namespace Lab6_Croteau
{
    class PersonV2 : Person  //inherit from Person class
    {
        private string cellPhone;
        private string instagramURL;


        //create a constructor for the PersonV2 class
        public PersonV2() : base() //this inherits the constructor from parent (Person in this case)
        {
            cellPhone = "";
            instagramURL = "";

        }

        public string CellPhone
        {
            get { return cellPhone; }

            set
            {
                //needs to be a 10 digits
                if (Validator.IsValidPhone(value))
                {
                    cellPhone = value; //store it
                }

                else
                {
                    //invalid phone number, give error message
                    Feedback += "ERROR: Please enter a 10 digit phone number including area code (i.e. 5551236789).\n";
                }
            }
        }

        public string InstagramURL
        {
            get
            {
                return instagramURL;
            }

            set
            {
                if (!Validator.GotBadWords(value))//just make sure there are no bad words
                {
                    instagramURL = value;
                }

                else
                {
                    Feedback += "ERROR: The Instagram URL cannot contain prohibited words.\n";
                }
            }
        }

        //**************************************************************************************
        //  Connect to the database
        //**************************************************************************************
        public string AddARecord()
        {
            //Init string var
            string strResult;

            //Make a connection object
            SqlConnection Conn = new SqlConnection();

            //Initialize it's properties
            Conn.ConnectionString = @"Server=sql.neit.edu,4500;Database=SE133_RCroteau;User Id=se133_rcroteau;Password=008012980;";     //Set the Who/What/Where of DB

            //attempt to connect to the server
            //*******************************************************************************************************
            // NEW
            //*******************************************************************************************************
            string strSQL = "INSERT INTO Persons (FirstName, Middle, LastName, Street1, Street2, City, State, ZipCode, Phone, Cell, Email, Instagram) VALUES (@FirstName, @Middle, @LastName, @Street1, @Street2, @City, @State, @ZipCode, @Phone, @Cell, @Email, @Instagram)";
            // Bark out our command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //Commander knows what to say
            comm.Connection = Conn;     //Where's the phone?  Here it is

            //Fill in the paramters (Has to be created in same sequence as they are used in SQL Statement)
            comm.Parameters.AddWithValue("@FirstName", FName);
            comm.Parameters.AddWithValue("@Middle", MName);
            comm.Parameters.AddWithValue("@LastName", LName);
            comm.Parameters.AddWithValue("@Street1", Street1);
            comm.Parameters.AddWithValue("@Street2", Street2);
            comm.Parameters.AddWithValue("@City", City);
            comm.Parameters.AddWithValue("@State", State);
            comm.Parameters.AddWithValue("@ZipCode", Zip);
            comm.Parameters.AddWithValue("@Phone", Phone);
            comm.Parameters.AddWithValue("@Cell", CellPhone);
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@Instagram", InstagramURL);


            //attempt to connect to the server and add record
            try
            {
                Conn.Open();                                        //Open connection to DB - Think of dialing a friend on phone
                int intRecs = comm.ExecuteNonQuery();
                strResult = $"SUCCESS: Inserted {intRecs} records.";       //Report that we made the connection and added a record
                Conn.Close();                                       //Hanging up after phone call
            }
            catch (Exception err)                                   //If we got here, there was a problem connecting to DB
            {
                strResult = "ERROR: " + err.Message;                //Set feedback to state there was an error & error info
            }
            finally
            {

            }



            //Return resulting feedback string
            return strResult;
        }
    }
}
