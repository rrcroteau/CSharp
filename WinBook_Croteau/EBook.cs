using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Use these namespaces to include DB capabilities for generic components and SQL Server
using System.Data;
using System.Data.SqlClient;

namespace WinBook_Croteau
{
    class EBook : Book //yay for inheritance!!
    {
        private DateTime dateRentalExpires;
        private int bookmarkPage;

        //default Constructor
        public EBook(): base() //calls the parent constructor
        {
            bookmarkPage = 0;
            dateRentalExpires = DateTime.Now.AddDays(14);
        }

        public DateTime DateRentalExpires
        {
            get { return dateRentalExpires; }

            set
            {
                //needs to be a future date
                if (Validator.IsFutureDate(value))
                {
                    dateRentalExpires = value; //store it
                }

                else
                {
                    //past date, give error
                    feedback += "\nERROR: You must enter a future date for the date the rental expires.";
                }
            }
        }

        public int BookmarkPage
        {
            get { return bookmarkPage; }

            set
            {
                //needs to be between 0 and the number of pages
                if (value >= 0 && value <= Pages)
                {
                    bookmarkPage = value; //store it
                }

                else
                {
                    //give feedback of invalid input
                    feedback += "\nERROR: Your bookmark must be between 0 and the number of pages in the book.";
                }
            }
        }

        //**************************************************************************************
        //  Ultimate goal is to add a record, BUT first we need to connect to the DB
        //    So that is how we will start this process.
        //**************************************************************************************
        public string AddARecord()
        {
            //Init string var
            string strResult;

            //Make a connection object
            SqlConnection Conn = new SqlConnection();

            //Initialize it's properties
            Conn.ConnectionString = @"Server=sql.neit.edu,4500;Database=SE133_RCroteau;User Id=se133_rcroteau;Password=008012980;";     //Set the Who/What/Where of DB


            //*******************************************************************************************************
            // NEW
            //*******************************************************************************************************
            string strSQL = "INSERT INTO EBooks (Title, AuthorFirst, AuthorLast, Email, Pages, DatePublished, DateRentalExpires, BookmarkPage, Price) VALUES (@Title, @AuthorFirst, @AuthorLast, @Email, @Pages, @DatePublished, @DateRentalExpires, @BookmarkPage, @Price)";
            // Bark out our command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //Commander knows what to say
            comm.Connection = Conn;     //Where's the phone?  Here it is

            //Fill in the paramters (Has to be created in same sequence as they are used in SQL Statement)
            comm.Parameters.AddWithValue("@Title", Title);
            comm.Parameters.AddWithValue("@AuthorFirst", AuthFName);
            comm.Parameters.AddWithValue("@AuthorLast", AuthLName);
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@Pages", Pages);
            comm.Parameters.AddWithValue("@DatePublished", DatePublished);
            comm.Parameters.AddWithValue("@DateRentalExpires", DateRentalExpires);
            comm.Parameters.AddWithValue("@BookmarkPage", BookmarkPage);
            comm.Parameters.AddWithValue("@Price", Price);

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
        public DataSet SearchEBooks(String strTitle, String strAuthorLast, String strEBookID)
        {
            //Create a dataset to return filled
            DataSet ds = new DataSet();


            //Create a command for our SQL statement
            SqlCommand comm = new SqlCommand();


            //Write a Select Statement to perform Search
            String strSQL = "SELECT EBook_ID, Title, AuthorFirst, AuthorLast FROM EBooks WHERE 0=0";

            //If the First/Last Name is filled in include it as search criteria
            if (strTitle.Length > 0)
            {
                strSQL += " AND Title LIKE @Title";
                comm.Parameters.AddWithValue("@Title", "%" + strTitle + "%");
            }
            if (strAuthorLast.Length > 0)
            {
                strSQL += " AND AuthorLast LIKE @AuthorLast";
                comm.Parameters.AddWithValue("@AuthorLast", "%" + strAuthorLast + "%");
            }
            if (strEBookID.Length > 0)
            {
                strSQL += " AND EBook_ID LIKE @EBook_ID";
                comm.Parameters.AddWithValue("@EBook_ID", "%" + strEBookID + "%");
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
            da.Fill(ds, "EBooks_Temp");     //Fill the dataset with results from database and call it "EBooks_Temp"
            conn.Close();               //Close the connection (hangs up phone)

            //Return the data
            return ds;
        }
        
        //NEW  - Method that returns a Data Reader filled with all the data
        // of one EBook.  This one EBook is specified by the ID passed
        // to this function
        public SqlDataReader FindOneEBook(int intEBook_ID)
        {
            //Create and Initialize the DB Tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //My Connection String
            string strConn = @GetConnected();

            //My SQL command string to pull up one EBook's data
            string sqlString =
           "SELECT * FROM EBooks WHERE EBook_ID = @EBook_ID;";

            //Tell the connection object the who, what, where, how
            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@EBook_ID", intEBook_ID);

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
