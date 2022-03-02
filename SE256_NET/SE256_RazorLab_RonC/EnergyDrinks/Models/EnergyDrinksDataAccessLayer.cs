using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//add using for the SQL DB componenet
using System.Data;
using System.Data.SqlClient;
//add the trouble ticket models folder
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

                //initialize feedback back to empty string to avoid re-using error messages each time a ticket is created
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
    }
}
