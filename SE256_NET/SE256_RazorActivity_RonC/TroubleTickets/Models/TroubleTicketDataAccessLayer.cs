using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//add using for the SQL DB componenet
using System.Data;
using System.Data.SqlClient;
//add the trouble ticket models folder
using TroubleTickets.Models;
//add the ability to use IConfiguration
using Microsoft.Extensions.Configuration;


namespace TroubleTickets.Models
{
    public class TroubleTicketDataAccessLayer
    {

        string connectionString; //string that will receive the connection string from the constructor

        private readonly IConfiguration _configuration; //instance of IConfiguration class...allows us to read in from config file like appsettings 

        //the Razor page that creates this data factory and passes the configuration object to it
        public TroubleTicketDataAccessLayer(IConfiguration configuration)
        {
            //via the config object we can collect the connection string for this project
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public void Create(TroubleTicketModel ticket)
        {
            //by using a "using" statement it is efficient because it deletes the connection and anything within the brackets when closed
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SQL statement to add a record with starter information (lacks response/solution ... that is for update)
                //we are using parameters to avoid complications with SQL injection attacks
                string sql = "INSERT Into TroubleTickets (Ticket_Title, Ticket_Desc, Category, Reporting_Email, Orig_Date) VALUES (@Ticket_Title, @Ticket_Desc, @Category, @Reporting_Email, @Orig_Date);";

                //initialize feedback back to empty string to avoid re-using error messages each time a ticket is created
                ticket.Feedback = "";

                //use TRY to attempt to connect with the resource, else it hits the CATCH

                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        //pass the sql string to the command
                        command.CommandType = CommandType.Text;
                        //fill in parameters
                        command.Parameters.AddWithValue("@Ticket_Title", ticket.Ticket_Title);
                        command.Parameters.AddWithValue("@Ticket_Desc", ticket.Ticket_Desc);
                        command.Parameters.AddWithValue("@Category", ticket.Category);
                        command.Parameters.AddWithValue("@Reporting_Email", ticket.Reporting_Email);
                        command.Parameters.AddWithValue("@Orig_Date", DateTime.Now); //pass the current date/time to the origination date of the ticket

                        //open the connection
                        connection.Open();

                        //pass the command and set the number of records affected to the feeback
                        ticket.Feedback = command.ExecuteNonQuery().ToString() + " Record(s) Added";

                        //close the connection
                        connection.Close();

                    }

                }

                catch (Exception err)
                {
                    //if an error occurs, add it to feedback
                    ticket.Feedback = "ERROR: " + err.Message;
                }

                //return RedirectToAction("Index"); //send us over to the index at this point
            }
        }

        //to view active trouble ticket details
        public IEnumerable<TroubleTicketModel> GetActiveRecords()
            {
                List<TroubleTicketModel> lstTix = new List<TroubleTicketModel>(); //list to hold trouble tickets from the DB
            
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string sql = "SELECT * FROM TroubleTickets ORDER BY Orig_Date;";
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.CommandType = CommandType.Text;

                        connection.Open();

                        SqlDataReader rdr = cmd.ExecuteReader(); //populate the data reader (rdr) from the DB

                        //loop through each record and fill a temp ticket for each one in the DB, then pass that ticket to an array which we will use to later display via cshtml

                        while (rdr.Read())
                        {
                            TroubleTicketModel ticket = new TroubleTicketModel();

                            ticket.Ticket_ID = Convert.ToInt32(rdr["Ticket_ID"]); //needed to convert it to an Int32
                            ticket.Ticket_Title = rdr["Ticket_Title"].ToString();
                            ticket.Category = rdr["Category"].ToString();
                            ticket.Reporting_Email = rdr["Reporting_Email"].ToString();
                            ticket.Orig_Date = DateTime.Parse(rdr["Orig_Date"].ToString()); //convert to string then date
                            ticket.Active = Boolean.Parse(rdr["Active"].ToString()); //convert to string then boolean
                            ticket.Responder_Email = rdr["Responder_Email"].ToString();
                            ticket.Responder_Notes = rdr["Responder_Notes"].ToString();

                            //add this new ticket to the array of tickets
                            lstTix.Add(ticket);
                        }

                        connection.Close();
                    }
                }

                catch (Exception err)
                {
                    //nothing at this point
                }

                return lstTix;

            }
    }

    
}
