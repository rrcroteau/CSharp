using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TroubleTickets.Models; //allows us to interact with classes/libraries in the Models folder
using System.Data;
using System.Data.SqlClient; //for use of sql DB components
using Microsoft.Extensions.Configuration; //so we can use IConfiguration to get the connection string from the appsettings.json

namespace TroubleTickets.Models
{
    public class TicketAdminDataAccessLayer
    {

        string connectionString; //string that will receive connection string from constructor

        //instance of IConfiguration class, allows us to read from appsettings.json file
        private readonly IConfiguration _configuration;

        //the razor page that creates the data factory and passes the configuration object to it
        public TicketAdminDataAccessLayer(IConfiguration configuration)
        {

            //via the configuration object, we can collect the connection string for this project
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        //to view the trouble ticket details
        public IEnumerable<TicketAdmin> GetAdminLogin(TicketAdmin tAdmin)
        {
            List<TicketAdmin> lstTicketAdmin = new List<TicketAdmin>(); //list to hold admins from DB

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string strSQL = "SELECT TOP 1 * FROM TicketAdmin_Registry WHERE TicketAdmin_Email = @TicketAdmin_Email AND TicketAdmin_PW = @TicketAdmin_PW;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.CommandType = CommandType.Text;

                    //fill in parameters with data from login form
                    cmd.Parameters.AddWithValue("@TicketAdmin_Email", tAdmin.TicketAdmin_Email);
                    cmd.Parameters.AddWithValue("@TicketAdmin_PW", tAdmin.TicketAdmin_PW);

                    //open a connection and populate a data reader
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    //loop throught each record, for each record fill a temp TicketAdmin object and add it to the list, which will be available to in the cshtml file
                    while (rdr.Read())
                    {
                        TicketAdmin tMatch = new TicketAdmin(); //create a temp object which will look for a match

                        //fill the temp obj with the results in the reader
                        tMatch.TicketAdmin_ID = Convert.ToInt32(rdr["TicketAdmin_ID"]);  //need to convert from obj to Int
                        tMatch.TicketAdmin_Email = rdr["TicketAdmin_Email"].ToString();  //convert obj to string
                        tMatch.TicketAdmin_PW = rdr["TicketAdmin_PW"].ToString();  //convert obj to string

                        lstTicketAdmin.Add(tMatch); //add the temp obj to the list
                    }

                    con.Close();
                }
            }

            catch (Exception err)
            {
                //nothing at this moment
            }

            return lstTicketAdmin; //return the list so the razor page can build the html from it
        }
    }
}
