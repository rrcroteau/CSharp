using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnergyDrinks.Models; //allows us to interact with classes/libraries in the Models folder
using System.Data;
using System.Data.SqlClient; //for use of sql DB components
using Microsoft.Extensions.Configuration; //so we can use IConfiguration to get the connection string from the appsettings.json

namespace EnergyDrinks.Models
{
    public class DrinkAdminDataAccessLayer
    {
        string connectionString; //string that will receive connection string from constructor

        //instance of IConfiguration class, allows us to read from appsettings.json file
        private readonly IConfiguration _configuration;

        //the razor page that creates the data factory and passes the configuration object to it
        public DrinkAdminDataAccessLayer(IConfiguration configuration)
        {

            //via the configuration object, we can collect the connection string for this project
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        //to view the trouble Drink details
        public IEnumerable<DrinkAdmin> GetAdminLogin(DrinkAdmin tAdmin)
        {
            List<DrinkAdmin> lstDrinkAdmin = new List<DrinkAdmin>(); //list to hold admins from DB

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string strSQL = "SELECT TOP 1 * FROM DrinkAdmin_Registry WHERE DrinkAdmin_Email = @DrinkAdmin_Email AND DrinkAdmin_PW = @DrinkAdmin_PW;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.CommandType = CommandType.Text;

                    //fill in parameters with data from login form
                    cmd.Parameters.AddWithValue("@DrinkAdmin_Email", tAdmin.DrinkAdmin_Email);
                    cmd.Parameters.AddWithValue("@DrinkAdmin_PW", tAdmin.DrinkAdmin_PW);

                    //open a connection and populate a data reader
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    //loop throught each record, for each record fill a temp DrinkAdmin object and add it to the list, which will be available to in the cshtml file
                    while (rdr.Read())
                    {
                        DrinkAdmin tMatch = new DrinkAdmin(); //create a temp object which will look for a match

                        //fill the temp obj with the results in the reader
                        tMatch.DrinkAdmin_ID = Convert.ToInt32(rdr["DrinkAdmin_ID"]);  //need to convert from obj to Int
                        tMatch.DrinkAdmin_Email = rdr["DrinkAdmin_Email"].ToString();  //convert obj to string
                        tMatch.DrinkAdmin_PW = rdr["DrinkAdmin_PW"].ToString();  //convert obj to string

                        lstDrinkAdmin.Add(tMatch); //add the temp obj to the list
                    }

                    con.Close();
                }
            }

            catch //(Exception err)
            {
                //nothing at this moment
            }

            return lstDrinkAdmin; //return the list so the razor page can build the html from it
        }
    }
}
