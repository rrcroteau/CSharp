using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//include these for session vars
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;


namespace TroubleTickets.Pages.Admin
{
    public class ControlPanelModel : PageModel
    {
        public IActionResult OnGet()
        {
            IActionResult temp; //temp result var

            //if the admin's email is not here, we will redirect them to the login page
            if (HttpContext.Session.GetString("TicketAdmin_Email") is null)
            {
                temp = RedirectToPage("/Admin/Index");
            }

            else
            {
                temp = Page(); 
            }

            return temp;
        }
    }
}
