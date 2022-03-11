using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EnergyDrinks.Models; //allows us to interact with classes/libraries in the Models folder
using Microsoft.Extensions.Configuration; //so we can use IConfiguration to get the connection string from the appsettings.json
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace EnergyDrinks.Pages.Admin
{
    public class IndexModel : PageModel
    {
        [BindProperty] //requires obj to come from a form
        public DrinkAdmin tAdmin { get; set; } //instance of an admin model
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
            List<DrinkAdmin> lstDrinkAdmin; //= new List<DrinkAdmin>(); //list to hold the admins from DB table

            if (ModelState.IsValid == false)  //if there are errors, point to this page
            {
                temp = Page();
            }

            else
            {
                if (tAdmin != null)
                {
                    DrinkAdminDataAccessLayer factory = new DrinkAdminDataAccessLayer(_configuration);

                    //runs the function to return the login search results
                    lstDrinkAdmin = factory.GetAdminLogin(tAdmin).ToList();

                    //if there is a record, store it in a session var and send user to control panel
                    if (lstDrinkAdmin.Count > 0)
                    {
                        HttpContext.Session.SetInt32("DrinkAdmin_ID", lstDrinkAdmin[0].DrinkAdmin_ID);
                        HttpContext.Session.SetString("DrinkAdmin_Email", lstDrinkAdmin[0].DrinkAdmin_Email);
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
