using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TroubleTickets.Models; //use in order create trouble ticket object

namespace TroubleTickets.Pages
{
    public class AddTicketModel : PageModel
    {
        [BindProperty] //requires obj to come from a form
        public TroubleTicketModel tTicket { get; set; } //create instance of ticket model

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
                temp = Page();
            }

            return temp; //return the resulting IActionResult
        }
    }
}
