using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SE256_Lab_RonC.App_Code
{
    #pragma warning disable 0436 //this is to get rid of the type conflict error with the Dance class
    public class Dance1 : Dance
    {
        
        //default Constructor
        public Dance1() : base() //calls the parent constructor
        {
            
        }

        //make a connection string function for use in DB Connection
        private string GetConnected()
        {
            return @"Server=sql.neit.edu,4500;Database=SE133_RCroteau;User Id=se133_rcroteau;Password=008012980;";
        }

        public string AddARecord()
        {
            //init a result string
            string strResult;

            //make a connection object
            SqlConnection Conn = new SqlConnection();

            //init the properties of the connection obj
            Conn.ConnectionString = GetConnected(); //use the connection string we created above in the function

            //create to string to be used as the command in SQL
            string strSQL = "INSERT INTO LineDances (DanceName, Choreo1FName, Choreo1LName, Choreo2FName, Choreo2LName, Choreo3FName, Choreo3LName, Music, Artist, LineOrPartner, Difficulty, Steps, Walls, DateChoreo) VALUES (@DanceName, @Choreo1FName, @Choreo1LName, @Choreo2FName, @Choreo2LName, @Choreo3FName, @Choreo3LName, @Music, @Artist, @LineOrPartner, @Difficulty, @Steps, @Walls, @DateChoreo)";

            //create the command obj
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL; //set the command text to the SQL string we created
            comm.Connection = Conn; //set the connection command to the connection wee made above

            //fill in the parameters with the data that was validated and set by the class (must match the order of the elements in the SQL statement above
            comm.Parameters.AddWithValue("@DanceName", DanceName);
            comm.Parameters.AddWithValue("@Choreo1FName", Choreo1FName);
            comm.Parameters.AddWithValue("@Choreo1LName", Choreo1LName);
            comm.Parameters.AddWithValue("@Choreo2FName", Choreo2FName);
            comm.Parameters.AddWithValue("@Choreo2LName", Choreo2LName);
            comm.Parameters.AddWithValue("@Choreo3FName", Choreo3FName);
            comm.Parameters.AddWithValue("@Choreo3LName", Choreo3LName);
            comm.Parameters.AddWithValue("@Music", Music);
            comm.Parameters.AddWithValue("@Artist", Artist);
            comm.Parameters.AddWithValue("@LineOrPartner", LineOrPartner);
            comm.Parameters.AddWithValue("@Difficulty", Difficulty);
            comm.Parameters.AddWithValue("@Steps", Steps);
            comm.Parameters.AddWithValue("@Walls", Walls);
            comm.Parameters.AddWithValue("@DateChoreo", DateChoreo);

            //attempt to connect to the server
            try
            {
                Conn.Open(); //open the connection to the server
                int intRecs = comm.ExecuteNonQuery(); //this will tell you then number of records affected by the command
                strResult = $"SUCCESS: Inserted {intRecs} records."; //let us know we made the connection and affected record(s).
                Conn.Close(); //close the connection now that we are done
            }
            
            catch (Exception err) //this means an exception was caught when connected or executing the command
            {
                strResult = "ERROR: " + err.Message; //set the feedback to the error message
            }

            finally
            {
                //have to have this here, even if it is empty
            }

            //return the result string
            return strResult;
        }

        //create a Search that stores the results into a DataReader for display back to the user
        public SqlDataReader SearchDances(String strDanceName, String strMusic)
        {
            //declare a DR to be returned fill
            SqlDataReader dr;

            //create the command obj
            SqlCommand comm = new SqlCommand();

            //write the SELECT statement to perform the SQL search
            string strSQL = "SELECT DanceID, DanceName, Choreo1FName, Choreo1LName, Music, Artist, LineOrPartner, Difficulty, Steps, Walls FROM LineDances WHERE 0=0";

            //if the dance name or music is filled, use it in the search criteria
            if (strDanceName.Length > 0)
            {
                strSQL += " AND DanceName LIKE @DanceName";
                comm.Parameters.AddWithValue("@DanceName", "%" + strDanceName + "%");
            }

            if (strMusic.Length > 0)
            {
                strSQL += " AND Music LIKE @Music";
                comm.Parameters.AddWithValue("@Music", "%" + strMusic + "%");
            }

            //create/finish the rest of the DB objects (conn and comm)
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = GetConnected();
            comm.Connection = conn;
            comm.CommandText = strSQL;

            //get the data and store it into the DR
            conn.Open();
            dr = comm.ExecuteReader(); //fill the DR

            //Note: cannot close connection here before returning the DR to the caller, or else it will get destroyed.  The connection will close automatically after function end

            //return the filled DR
            return dr;
        }

        public SqlDataReader FindOneDance(int intDanceID)
        {
            //create and init the DB tools
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //create the SQL string to pull up the Dance based on the DanceID
            string sqlString = "SELECT * FROM LineDances WHERE DanceID = @DanceID;";

            conn.ConnectionString = GetConnected();
            //give the command obj what it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@DanceID", intDanceID);

            //open the DB
            conn.Open();

            //execute the reader and return the DR to the calling function
            return comm.ExecuteReader();  //the connection will close automatically when the function ends

        }

        //create a method to delete one EBook based on the EBook ID
        public string DeleteOneDance(int intDanceID)
        {
            Int32 intRecords;
            string strResult;

            //create and init the needed DB objects
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //give the connection string to the conn object
            conn.ConnectionString = GetConnected();

            //create the SQL string to pass to the comm object
            string sqlString = "DELETE FROM LineDances WHERE DanceID = @DanceID;";

            //give the command the info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@DanceID", intDanceID);

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
            string strSQL = "UPDATE LineDances SET DanceName = @DanceName, Choreo1FName = @Choreo1FName, Choreo1LName = @Choreo1LName, Choreo2FName = @Choreo2FName, Choreo2LName = @Choreo2LName, Choreo3FName = @Choreo3FName, Choreo3LName = @Choreo3LName, Music = @Music, Artist = @Artist, LineOrPartner = @LineOrPartner, Difficulty = @Difficulty, Steps = @Steps, Walls = @Walls, DateChoreo = @DateChoreo WHERE DanceID = @DanceID";

            //create and give the command to the server
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //Make the SQL string the command
            comm.Connection = conn;     //set up the connection command

            //Fill in the parameters (Has to be created in same sequence as they are used in SQL Statement)
            comm.Parameters.AddWithValue("@DanceName", DanceName);
            comm.Parameters.AddWithValue("@Choreo1FName", Choreo1FName);
            comm.Parameters.AddWithValue("@Choreo1LName", Choreo1LName);
            comm.Parameters.AddWithValue("@Choreo2FName", Choreo2FName);
            comm.Parameters.AddWithValue("@Choreo2LName", Choreo2LName);
            comm.Parameters.AddWithValue("@Choreo3FName", Choreo3FName);
            comm.Parameters.AddWithValue("@Choreo3LName", Choreo3LName);
            comm.Parameters.AddWithValue("@Music", Music);
            comm.Parameters.AddWithValue("@Artist", Artist);
            comm.Parameters.AddWithValue("@LineOrPartner", LineOrPartner);
            comm.Parameters.AddWithValue("@Difficulty", Difficulty);
            comm.Parameters.AddWithValue("@Steps", Steps);
            comm.Parameters.AddWithValue("@Walls", Walls);
            comm.Parameters.AddWithValue("@DateChoreo", DateChoreo);
            comm.Parameters.AddWithValue("@DanceID", Dance_ID);

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