using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Use these namespaces to include DB capabilities for generic components and SQL Server
using System.Data;
using System.Data.SqlClient;

namespace SE256_Activity_RonC.App_Code
{
    class EBook : Book 
    {
        private DateTime dateRentalExpires;
        private int bookmarkPage;

        //***************************************************************************
        //NEW - Created this var to hold the EBook's ID assigned by the DB
        private int eBook_ID;
        //***************************************************************************

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

        public Int32 EBook_ID
        {
            get
            {
                return eBook_ID;
            }

            set
            {
              
                if (value >= 0)
                {
                    eBook_ID = value;  //store the ID
                }
                else
                {
                    //Store an error msg in Feedback
                    feedback += "\nERROR: Sorry you entered an invalid EBook ID.";
                }
            }
        }

        //make a connection string function for use in DB Connection
        private string GetConnected()
        {
            return @"Server=sql.neit.edu,4500;Database=SE133_RCroteau;User Id=se133_rcroteau;Password=008012980;";
        }

        //default Constructor
        public EBook() : base() //calls the parent constructor
        {
            bookmarkPage = 0;
            dateRentalExpires = DateTime.Now.AddDays(14);
        }

        //create function that will connect to a DB and add a record to it
        public string AddARecord()
        {
            //Init string var
            string strResult;

            //Make a connection object
            SqlConnection Conn = new SqlConnection();

            //Initialize it's properties to get connected
            Conn.ConnectionString = @GetConnected(); 


            //create the SQL string to insert the record into the DB
            string strSQL = "INSERT INTO EBooks (Title, AuthorFirst, AuthorLast, Email, Pages, DatePublished, DateRentalExpires, BookmarkPage, Price) VALUES (@Title, @AuthorFirst, @AuthorLast, @Email, @Pages, @DatePublished, @DateRentalExpires, @BookmarkPage, @Price)";
            //create and give the command to the server
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //Make the SQL string the command
            comm.Connection = Conn;     //set up the connection command

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

        
    }

}
