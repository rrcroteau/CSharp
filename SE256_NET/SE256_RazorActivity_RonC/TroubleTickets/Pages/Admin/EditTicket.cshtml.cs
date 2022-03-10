using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TroubleTickets.Models; //to have access to the models folder and create temp ticket object
//add the ability to use IConfiguration
using Microsoft.Extensions.Configuration;


namespace TroubleTickets.Pages.Admin
{
    public class EditTicketModel : PageModel
    {

        private readonly IConfiguration _configuration; //instance of IConfiguration class...allows us to read in from config file like appsettings 

        [BindProperty] //required object to come from a form
        public TroubleTicketModel tTicket { get; set; } //instance of ticket model
        public TroubleTicketDataAccessLayer factory;

        public EditTicketModel(IConfiguration configuration)
        {
            //constructor code
            _configuration = configuration;
            factory = new TroubleTicketDataAccessLayer(_configuration);
        }

        //when this page is loaded, this function will run IF the int form of the ID is passed
        public IActionResult OnGet(int? id)
        {
            if (id == null) //if the ID is null, return the built in not found error
            {
                return NotFound();
            }
            else //if an ID is passed, pass the ID to the method, which will fill the ticket
            {
                tTicket = factory.GetOneRecord(id);
            }

            if (tTicket == null) //if the ticket is null, return the built in not found error
            {
                return NotFound();
            }

            return Page();

        }

        public IActionResult OnPost() //we will call this when we hit the Update button
        {
            if (!ModelState.IsValid) //if not valid form info, stay here to display errors
            {
                return Page();
            }

            factory.UpdateTicket(tTicket); //else run our Update function in the data factory
            return RedirectToPage("/Admin/ControlPanel"); //redirect to list of tickets 

        }
    }
}
