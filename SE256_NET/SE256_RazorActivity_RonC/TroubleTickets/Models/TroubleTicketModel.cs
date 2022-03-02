using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //necessary for Validations
using System.Linq;
using System.Threading.Tasks;

namespace TroubleTickets.Models
{
    public class TroubleTicketModel
    {
        [Required]
        public int Ticket_ID { get; set; } //Primary Key, Identity Spec

        [Required, StringLength(255)]
        public string Ticket_Title { get; set; } //basic description (255 chars)

        [Required]
        public string Ticket_Desc { get; set; } //more descriptive than the title, text field

        //this uses ValidationLib class to set an array used for validation and the appropriate error message should the input not be in the list
        [Required]
        [StringOptionsValidate(Allowed = new string[] { "Monitor", "Computer", "Printer", "Software Install", "Software Upgrade", "Configuration", "Internet"}, ErrorMessage = "Sorry, your Category is invalid. Acceptable Categories: Monitor, Computer, Printer, Software Install, Software Upgrade, Configuration, Internet")]
        public string Category { get; set; } //enum to categorize the problem falls into 

        [Required, EmailAddress]
        public string Reporting_Email { get; set; } //email of person reporting the problem

        [Required]
        [Display(Name ="Original Date of the Problem")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        [MyDate(ErrorMessage = "Future date entry not allowed")]
        public DateTime Orig_Date { get; set; } //date ticket was posted

        [Required]
        [Display(Name = "Date of Solution/Closure")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        [MyDate(ErrorMessage = "Future date entry not allowed")]
        public DateTime Close_Date { get; set; } //date ticket is considered closed

        public string Responder_Notes { get; set; } //notes from the responding tech support (text)

        [EmailAddress]
        public string Responder_Email { get; set; } //email of the responding tech support

        [Required]
        public bool Active { get; set; } //ticket is open (true) or closed (false) - Binary field

        public string Feedback { get; set; }  //used to share feedback with the user
    }
} 
