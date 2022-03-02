using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TroubleTickets.Models; //use in order create trouble ticket object
//add the ability to use IConfiguration
using Microsoft.Extensions.Configuration;

namespace TroubleTickets.Pages
{
    public class AddTicketModel : PageModel
    {
        [BindProperty] //requires obj to come from a form
        public TroubleTicketModel tTicket { get; set; } //create instance of ticket model

        private readonly IConfiguration _configuration; //instance of IConfiguration class...allows us to read in from config file like appsettings 

        public AddTicketModel(IConfiguration configuration)
        {
            //constructor code
            _configuration = configuration;
        }

        //nothing here yet on original page load
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            IActionResult temp; //temporary result variable

            if (ModelState.IsValid == false) //if there are errors, point to this page
            {
                temp = Page();
            }

            else
            {
                if (tTicket is null == false)
                {
                    TroubleTicketDataAccessLayer factory = new TroubleTicketDataAccessLayer(_configuration);

                    factory.Create(tTicket); //runs the Create function to add a record 
                }
                temp = Page();
            }

            return temp; //return the resulting IActionResult
        }
    }
}
