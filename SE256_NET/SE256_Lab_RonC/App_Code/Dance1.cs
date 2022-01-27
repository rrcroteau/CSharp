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
            comm.Parameters.AddWithValue("DateChoreo", DateChoreo);

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
    }
}