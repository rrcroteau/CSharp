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
        //  NEW - Ultimate goal is to add a record, BUT first we need to connect to the DB
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
    }
}
