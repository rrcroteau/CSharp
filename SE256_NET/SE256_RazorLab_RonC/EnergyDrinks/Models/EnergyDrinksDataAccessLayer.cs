using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//add using for the SQL DB componenet
using System.Data;
using System.Data.SqlClient;
//add the energy drink models folder
using EnergyDrinks.Models;
//add the ability to use IConfiguration
using Microsoft.Extensions.Configuration;


namespace EnergyDrinks.Models
{
    public class EnergyDrinksDataAccessLayer
    {
        string connectionString; //string that will receive the connection string from the constructor

        private readonly IConfiguration _configuration; //instance of IConfiguration class...allows us to read in from config file like appsettings 

        //the Razor page that creates this data factory and passes the configuration object to it
        public EnergyDrinksDataAccessLayer(IConfiguration configuration)
        {
            //via the config object we can collect the connection string for this project
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public void Create(EnergyDrinksModel drink)
        {
            //by using a "using" statement it is efficient because it deletes the connection and anything within the brackets when closed
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SQL statement to add a record with starter information (lacks response/solution ... that is for update)
                //we are using parameters to avoid complications with SQL injection attacks
                string sql = "INSERT Into EnergyDrinks (Mfr, Name, Flavor, Size, Price, Support_Email, Release_Date) VALUES (@Mfr, @Name, @Flavor, @Size, @Price, @Support_Email, @Release_Date);";

                //initialize feedback back to empty string to avoid re-using error messages each time a drink is created
                drink.Feedback = "";

                //use TRY to attempt to connect with the resource, else it hits the CATCH

                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        //pass the sql string to the command
                        command.CommandType = CommandType.Text;
                        //fill in parameters
                        command.Parameters.AddWithValue("@Mfr", drink.Mfr);
                        command.Parameters.AddWithValue("@Name", drink.Name);
                        command.Parameters.AddWithValue("@Flavor", drink.Flavor);
                        command.Parameters.AddWithValue("@Size", drink.Size);
                        command.Parameters.AddWithValue("@Price", drink.Price);
                        command.Parameters.AddWithValue("@Support_Email", drink.Support_Email);
                        command.Parameters.AddWithValue("@Release_Date", drink.Release_Date); 

                        //open the connection
                        connection.Open();

                        //pass the command and set the number of records affected to the feeback
                        drink.Feedback = command.ExecuteNonQuery().ToString() + " Record(s) Added";

                        //close the connection
                        connection.Close();

                    }

                }

                catch (Exception err)
                {
                    //if an error occurs, add it to feedback
                    drink.Feedback = "ERROR: " + err.Message;
                }

                //return RedirectToAction("Index"); //send us over to the index at this point
            }
        }

        //to view active trouble drink details
        public IEnumerable<EnergyDrinksModel> GetActiveRecords()
        {
            List<EnergyDrinksModel> ListDrinks = new List<EnergyDrinksModel>(); //list to hold drinks from the DB

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "SELECT * FROM EnergyDrinks ORDER BY Release_Date;";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;

                    connection.Open();

                    SqlDataReader rdr = cmd.ExecuteReader(); //populate the data reader (rdr) from the DB

                    //loop through each record and fill a temp drink for each one in the DB, then pass that drink to an array which we will use to later display via cshtml

                    while (rdr.Read())
                    {
                        EnergyDrinksModel drink = new EnergyDrinksModel();

                        drink.Drink_ID = Convert.ToInt32(rdr["Drink_ID"]); //needed to convert it to an Int32
                        drink.Mfr = rdr["Mfr"].ToString();
                        drink.Name = rdr["Name"].ToString();
                        drink.Flavor = rdr["Flavor"].ToString();
                        drink.Size = rdr["Size"].ToString();
                        drink.Price = rdr["Price"].ToString();
                        drink.Support_Email = rdr["Support_Email"].ToString();
                        drink.Release_Date = DateTime.Parse(rdr["Release_Date"].ToString()); //convert to string then date
                        drink.Active = Boolean.Parse(rdr["Active"].ToString()); //convert to string then boolean


                        //add this new drink to the array of drinks
                        ListDrinks.Add(drink);
                    }

                    connection.Close();
                }
            }

            catch (Exception err)
            {
                //nothing at this point
            }

            return ListDrinks;

        }

        //code to find one specific record based on ID (the drink we want to edit) -- we need to use "id" here due to the routing referred to the third component of the URL route as "id"
        public EnergyDrinksModel GetOneRecord(int? id)
        {
            EnergyDrinksModel drink = new EnergyDrinksModel(); //the obj to hold the record based on ID

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //config the command obj with the SQL statement and connection
                    string strSQL = "SELECT * FROM EnergyDrinks WHERE Drink_ID = @Drink_ID;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.CommandType = CommandType.Text;

                    //set the ID param
                    cmd.Parameters.AddWithValue("Drink_ID", id);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(); //populate the DR

                    //loop through the record, fill a temp drink object with the data from each record, add the object to the list, then we can use that to display with CSHTML
                    while (rdr.Read())
                    {
                        drink.Drink_ID = Convert.ToInt32(rdr["Drink_ID"]); //needed to convert it to an Int32
                        drink.Mfr = rdr["Mfr"].ToString();
                        drink.Name = rdr["Name"].ToString();
                        drink.Flavor = rdr["Flavor"].ToString();
                        drink.Size = rdr["Size"].ToString();
                        drink.Price = rdr["Price"].ToString();
                        drink.Support_Email = rdr["Support_Email"].ToString();
                        drink.Release_Date = DateTime.Parse(rdr["Release_Date"].ToString()); //convert to string then date
                        drink.Active = Boolean.Parse(rdr["Active"].ToString()); //convert to string then boolean
                    }

                    con.Close();

                }
            }
            catch (Exception err)
            {
                drink.Feedback = "Error" + err.Message; //if we encountered an error, display it in feedback
            }

            return drink; //return the filled list object so the razor page can build the html from it
        }

        //to update records of a particular trouble ticket
        public void UpdateDrink(EnergyDrinksModel TempDrink)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(); //create a basic command object, we will at the SQL command and connection later

                    
                    string strSQL;

                    strSQL = "UPDATE EnergyDrinks SET Price = @Price, Support_Email = @Support_Email, Active = @Active WHERE Drink_ID = @Drink_ID;";



                    //configure the command object
                    cmd.CommandText = strSQL;
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;

                    //fill the parameters with the values
                    cmd.Parameters.AddWithValue("@Price", TempDrink.Price);
                    cmd.Parameters.AddWithValue("@Support_Email", TempDrink.Support_Email);

                    cmd.Parameters.AddWithValue("@Active", TempDrink.Active);
                    cmd.Parameters.AddWithValue("@Drink_ID", TempDrink.Drink_ID);

                    //execute the update
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception err)
            {
                //report the error if one occurs
                TempDrink.Feedback = "ERROR: " + err.Message;
            }
        }

        //to delete a particular record based on the ticket ID
        public EnergyDrinksModel DeleteDrink(int? id)
        {
            EnergyDrinksModel ticket = new EnergyDrinksModel(); //placeholder obj to hold the record based on ID
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string strSQL = "DELETE FROM EnergyDrinks WHERE Drink_ID = @Drink_ID;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Drink_ID", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception err)
            {
                ticket.Feedback = "ERROR: " + err.Message; //if there is an error, put it in feedback
            }

            return ticket;

        }
    }
}
