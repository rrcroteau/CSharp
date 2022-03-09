using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //validation via Data Annotiations
using TroubleTickets.Models; //allows us to interact with classes/libraries in the Models folder
using System.Data;
using System.Data.SqlClient; //for use of sql DB components
using Microsoft.Extensions.Configuration; //so we can use IConfiguration to get the connection string from the appsettings.json
//for session vars
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace TroubleTickets.Models
{
    public class TicketAdmin
    {
        [Required]
        public int TicketAdmin_ID { get; set; }  //primary key, id spec

        [EmailAddress]
        [Display(Name = "Username")]
        public string TicketAdmin_Email { get; set; }  //email of the admin/responder

        [Required, StringLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string TicketAdmin_PW { get; set; } //basic PW (20 chars)

        public string Feedback { get; set; }  //used to provide feedback
    }
}
