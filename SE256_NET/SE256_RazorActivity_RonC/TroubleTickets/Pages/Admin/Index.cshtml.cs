using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TroubleTickets.Models; //allows us to interact with classes/libraries in the Models folder
using Microsoft.Extensions.Configuration; //so we can use IConfiguration to get the connection string from the appsettings.json
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace TroubleTickets.Pages.Admin
{
    public class IndexModel : PageModel
    {
        [BindProperty] //requires obj to come from a form
        public TicketAdmin tAdmin { get; set; } //instance of an admin model
        private readonly IConfiguration _configuration; //instance of configuration class, allows us to read from appsettings.json file

        //create constructor
        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        public void OnGet()
        {
        }

        //event handler for post events
        public IActionResult OnPost()
        {
            IActionResult temp; //temp result var
            List<TicketAdmin> lstTicketAdmin = new List<TicketAdmin>(); //list to hold the admins from DB table

            if (ModelState.IsValid == false)  //if there are errors, point to this page
            {
                temp = Page();
            }

            else
            {
                if (tAdmin != null)
                {
                    TicketAdminDataAccessLayer factory = new TicketAdminDataAccessLayer(_configuration);

                    //runs the function to return the login search results
                    lstTicketAdmin = factory.GetAdminLogin(tAdmin).ToList();

                    //if there is a record, store it in a session var and send user to control panel
                    if (lstTicketAdmin.Count > 0)
                    {
                        HttpContext.Session.SetInt32("TicketAdmin_ID", lstTicketAdmin[0].TicketAdmin_ID);
                        HttpContext.Session.SetString("TicketAdmin_Email", lstTicketAdmin[0].TicketAdmin_Email);
                        temp = Redirect("/Admin/ControlPanel");
                    }
                    else
                    {
                        tAdmin.Feedback = "Login Failed"; //no record was found (logini failed), tell them it failed and keep them on this page
                        temp = Page();
                    }
                }
                else
                {
                    temp = Page(); //if tAdmin is null, keep them on the page
                }
            }

            return temp; //return the IActionResult
        }
    }
}
