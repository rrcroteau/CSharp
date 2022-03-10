using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TroubleTickets.Models; //included to create a temp ticket obj
//add the ability to use IConfiguration
using Microsoft.Extensions.Configuration;

namespace TroubleTickets.Pages.Admin
{
    public class DeleteTicketModel : PageModel
    {
        TroubleTicketDataAccessLayer factory;
        public TroubleTicketModel tTicket { get; set; }
        private readonly IConfiguration _configuration; //instance of IConfiguration class...allows us to read in from config file like appsettings 

        public DeleteTicketModel(IConfiguration configuration)
        {
            //constructor
            _configuration = configuration;
            factory = new TroubleTicketDataAccessLayer(_configuration);
        }

        //when the page initially loads (not during a post (submit) event), we look for an ID... if the ID is there and not null, we use GetOneRecord to pull that record up
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound(); //if null, return built in NotFound
            }

            tTicket = factory.GetOneRecord(id); //and ID exists, so send it to the factory to populate the ticket obj based on the ID

            if (tTicket == null) //if tTicket is still null at this point, tell them we couldn't find (ie. the ID isnt' in the DB)
            {
                return NotFound();
            }
            return Page(); //otherwise, return the page data
        }

        //use the small simple form on the CSHTML page to POST and delete the ticket associated with the ID
        public IActionResult OnPost(int? id)
        {
            if (id == null) //if id is null, display NotFound
            {
                return NotFound();
            }

            factory.DeleteTicket(id); //delete the record based on the ID

            return RedirectToPage("/Admin/ControlPanel"); //return back to control panel (the record should be deleted now)
        }
    }
}
