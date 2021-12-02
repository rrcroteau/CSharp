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
                //needs to be 10 digits
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

        //**************************************************************************************
        //  NEW - Part one of drill-down search (Takes search params to narrow the search results
        //**************************************************************************************
        public DataSet SearchPersons(String strLName, String strState, String strPersonID)
        {
            //Create a dataset to return filled
            DataSet ds = new DataSet();


            //Create a command for our SQL statement
            SqlCommand comm = new SqlCommand();


            //Write a Select Statement to perform Search
            String strSQL = "SELECT PersonID, FirstName, Middle, LastName, Street1, Street2, City, State, ZipCode, Phone, Cell, Email, Instagram FROM Persons WHERE 0=0";

            //If the First/Last Name is filled in include it as search criteria
            if (strLName.Length > 0)
            {
                strSQL += " AND LastName LIKE @LastName";
                comm.Parameters.AddWithValue("@LastName", "%" + strLName + "%");
            }
            if (strState.Length > 0)
            {
                strSQL += " AND State LIKE @State";
                comm.Parameters.AddWithValue("@State", "%" + strState + "%");
            }
            if (strPersonID.Length > 0)
            {
                strSQL += " AND PersonID LIKE @PersonID";
                comm.Parameters.AddWithValue("@PersonID", "%" + strPersonID + "%");
            }


            //Create DB tools and Configure
            //*********************************************************************************************
            SqlConnection conn = new SqlConnection();
            //Create the who, what where of the DB
            string strConn = @GetConnected();
            conn.ConnectionString = strConn;

            //Fill in basic info to command object
            comm.Connection = conn;     //tell the commander what connection to use
            comm.CommandText = strSQL;  //tell the command what to say

            //Create Data Adapter
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;    //commander needs a translator(dataAdapter) to speak with datasets

            //*********************************************************************************************

            //Get Data
            conn.Open();                //Open the connection (pick up the phone)
            da.Fill(ds, "Persons_Temp");     //Fill the dataset with results from database and call it "Persons_Temp"
            conn.Close();               //Close the connection (hangs up phone)

            //Return the data
            return ds;
        }

        //NEW  - Method that returns a Data Reader filled with all the data
        // of one Person.  This one Person is specified by the ID passed
        // to this function
        public SqlDataReader FindOnePerson(int intPersonID)
        {
            //Create and Initialize the DB Tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //My Connection String
            string strConn = @GetConnected();

            //My SQL command string to pull up one EBook's data
            string sqlString = "SELECT * FROM Persons WHERE PersonID = @PersonID;";

            //Tell the connection object the who, what, where, how
            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@PersonID", intPersonID);

            //Open the DataBase Connection and Yell our SQL Command
            conn.Open();

            //Return some form of feedback
            return comm.ExecuteReader();   //Return the dataset to be used by others (the calling form)

        }

        //**************************************************************************************
        //  NEW - Utility function so that one string controls all SQL Server Login info
        //**************************************************************************************
        private string GetConnected()
        {
            return "Server=sql.neit.edu,4500;Database=SE133_RCroteau;User Id=se133_rcroteau;Password=008012980;";
        }
    }
}
