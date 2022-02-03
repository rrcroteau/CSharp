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
            SqlConnection conn = new SqlConnection();

            //Initialize it's properties to get connected
            conn.ConnectionString = @GetConnected(); 


            //create the SQL string to insert the record into the DB
            string strSQL = "INSERT INTO EBooks (Title, AuthorFirst, AuthorLast, Email, Pages, DatePublished, DateRentalExpires, BookmarkPage, Price) VALUES (@Title, @AuthorFirst, @AuthorLast, @Email, @Pages, @DatePublished, @DateRentalExpires, @BookmarkPage, @Price)";
            //create and give the command to the server
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //Make the SQL string the command
            comm.Connection = conn;     //set up the connection command

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
                conn.Open();                                        //Open connection to DB - Think of dialing a friend on phone
                int intRecs = comm.ExecuteNonQuery();
                strResult = $"SUCCESS: Inserted {intRecs} records.";       //Report that we made the connection and added a record
                conn.Close();                                       //Hanging up after phone call
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

        //create a Search that returns a DataSet -- this is used to populate a DataGrid, which basically looks like a spreadsheet
        public DataSet SearchEBooks_DS(String strTitle, String strAuthorLast)
        {
            //create the DS obj, which we will return filled at the end of the function
            DataSet ds = new DataSet();

            //create a command obj to pass the commands
            SqlCommand comm = new SqlCommand();

            //write the SQL SELECT string to pass to command later
            String strSql = "SELECT EBook_ID, Title, AuthorFirst, AuthorLast, DatePublished FROM EBooks WHERE 0=0"; //this will return all records if no criteria are entered

            //add to the SELECT string if the user entered criteria in the search boxes
            if (strTitle.Length >0)
            {
                strSql += " AND Title LIKE @Title";
                comm.Parameters.AddWithValue("@Title", "%" + strTitle + "%");
            }

            if (strAuthorLast.Length >0)
            {
                strSql += " AND AuthorLast LIKE @AuthorLast";
                comm.Parameters.AddWithValue("@AuthorLast", "%" + strAuthorLast + "%");
            }

            //create the connection obj and give it the connection string
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = GetConnected();

            //fill the command obj from earlier with the newly created/updated objects
            comm.Connection = conn;
            comm.CommandText = strSql;

            //DataSets need a DataAdapter, so create one and give it the command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;

            //open the connection, get the data, and close the connection
            conn.Open();
            da.Fill(ds, "EBooks_Temp"); //use the adapter to fill the DS and call it by a temp name (to avoid confusion with the actual Table in the DB)
            conn.Close();

            //return the DS
            return ds;
        }

        //*****
        //Create a Search that returns a DataReader object... This can be used to create a more customizable return to the user using a Repeater or Literal, for example
        //*****

        public SqlDataReader SearchEBooks_DR(String strTitle, String strAuthorLast)
        {
            //create the DR obj that we will return filled
            SqlDataReader dr;

            //create a command obj to pass the commands
            SqlCommand comm = new SqlCommand();

            //write the SQL SELECT string to pass to command later
            String strSql = "SELECT EBook_ID, Title, AuthorFirst, AuthorLast, DatePublished FROM EBooks WHERE 0=0"; //this will return all records if no criteria are entered

            //add to the SELECT string if the user entered criteria in the search boxes
            if (strTitle.Length > 0)
            {
                strSql += " AND Title LIKE @Title";
                comm.Parameters.AddWithValue("@Title", "%" + strTitle + "%");
            }

            if (strAuthorLast.Length > 0)
            {
                strSql += " AND AuthorLast LIKE @AuthorLast";
                comm.Parameters.AddWithValue("@AuthorLast", "%" + strAuthorLast + "%");
            }

            //create the connection obj and give it the connection string
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = GetConnected();

            //fill the command obj from earlier with the newly created/updated objects
            comm.Connection = conn;
            comm.CommandText = strSql;

            //open the connection, get the data into the DR (cannot manaully close connection with a DR obj or it will be destroyed before return, but connection will auto-close when function ends)
            conn.Open();
            dr = comm.ExecuteReader();


            //return the filled DR
            return dr;
        }//the connection we didn't manually close above will now close since the function is complete -- this way we can reach the return statement with the DR intact

        //create a method to return a DR object of a specific database row based on ID an display the results
        public SqlDataReader FindOneEBook(int intEBook_ID)
        {
            //create and init the needed DB objects
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //give the connection string to the conn object
            conn.ConnectionString = GetConnected();

            //create the SQL string to pass to the comm object
            string sqlString = "SELECT * FROM EBooks WHERE EBook_ID = @Ebook_ID;";

            //give the command the info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@EBook_ID", intEBook_ID);

            //open the connection to execute the reader
            conn.Open();


            //return the results to the calling form
            return comm.ExecuteReader();
        }

        //create a method to delete one EBook based on the EBook ID
        public string DeleteOneEBook(int intEBook_ID)
        {
            Int32 intRecords;
            string strResult;

            //create and init the needed DB objects
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //give the connection string to the conn object
            conn.ConnectionString = GetConnected();

            //create the SQL string to pass to the comm object
            string sqlString = "DELETE FROM EBooks WHERE EBook_ID = @Ebook_ID;";

            //give the command the info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@EBook_ID", intEBook_ID);

            try
            {
                //open the connection
                conn.Open();

                //delete the record and store number of records affected
                intRecords = comm.ExecuteNonQuery();
                strResult = intRecords.ToString() + " Records Deleted.";
            }
            catch (Exception err)
            {
                strResult = "ERROR: " + err.Message; //set the feedback to show the error message
            }
            finally
            {
                //close the connection
                conn.Close();
            }


            return strResult;
        }

        //create a method to Update a record
        public string UpdateARecord()
        {
            //Declare stringvar 
            string strResult;
    

            //Make a connection object
            SqlConnection conn = new SqlConnection();

            //Initialize it's properties to get connected
            conn.ConnectionString = @GetConnected();


            //create the SQL string to insert the record into the DB
            string strSQL = "UPDATE EBooks SET Title = @Title, AuthorFirst = @AuthorFirst, AuthorLast = @AuthorLast, Email = @Email, Pages = @Pages, DatePublished = @DatePublished, DateRentalExpires = @DateRentalExpires, BookmarkPage = @BookmarkPage, Price = @Price WHERE EBook_ID = @EBook_ID";
            //create and give the command to the server
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //Make the SQL string the command
            comm.Connection = conn;     //set up the connection command

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
            comm.Parameters.AddWithValue("@EBook_ID", EBook_ID);

            //attempt to connect to the server and add record
            try
            {
                conn.Open();                                        //Open connection to DB - Think of dialing a friend on phone
                int intRecords = comm.ExecuteNonQuery();
                strResult = intRecords.ToString() + " Records Updated.";       //Report that we made the connection and updated a record
                                                    //Hanging up after phone call
            }
            catch (Exception err)                                   //If we got here, there was a problem connecting to DB
            {
                strResult = "ERROR: " + err.Message;                //Set feedback to state there was an error & error info
            }
            finally
            {
                //close the connection
                conn.Close();
            }



            //Return resulting feedback string
            return strResult;
        }

    }

}
