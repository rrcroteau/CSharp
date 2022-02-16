using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroubleTickets.Models
{
    public class TroubleTicketModel
    {
        public int Ticket_ID { get; set; } //Primary Key, Identity Spec

        public string Ticket_Title { get; set; } //basic description (255 chars)

        public string Ticket_Desc { get; set; } //more descriptive than the title, text field

        public string Category { get; set; } //category the problem falls into 

        public string Reporting_Email { get; set; } //email of person reporting the problem

        public DateTime Orig_Date { get; set; } //date ticket was posted

        public DateTime Close_Date { get; set; } //date ticket is considered closed

        public string Responder_Notes { get; set; } //notes from the responding tech support (text)

        public string Responder_Email { get; set; } //email of the responding tech support

        public bool Active { get; set; } //ticket is open (true) or closed (false) - Binary field
    }
}
