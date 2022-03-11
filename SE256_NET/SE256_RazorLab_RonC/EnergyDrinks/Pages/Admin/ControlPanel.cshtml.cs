using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//include these for session vars
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using EnergyDrinks.Models; //to have access to models folder
using Microsoft.Extensions.Configuration; //in order to use IConfiguration to get the connection string from appsettings.json file


namespace EnergyDrinks.Pages.Admin
{
    public class ControlPanelModel : PageModel
    {
        //instance of Inconfiguratin model to get config settings
        private readonly IConfiguration _configuration;

        EnergyDrinksDataAccessLayer factory;
        public List<EnergyDrinksModel> Drinks { get; set; }

        public ControlPanelModel(IConfiguration configuration)
        {
            //constructor
            _configuration = configuration;
            factory = new EnergyDrinksDataAccessLayer(_configuration);
        }

        public IActionResult OnGet()
        {
            IActionResult temp; //temp result var

            //if the admin's email is not here, we will redirect them to the login page
            if (HttpContext.Session.GetString("DrinkAdmin_Email") is null)
            {
                temp = RedirectToPage("/Admin/Index");
            }

            else
            {
                Drinks = factory.GetActiveRecords().ToList(); //fill the currently empty list with records
                temp = Page(); //keep them on this page
            }

            return temp;
        }
    }
}
