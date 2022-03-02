using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EnergyDrinks.Models; //included in order to make a temporary energy drink model
//add the ability to use IConfiguration
using Microsoft.Extensions.Configuration;

namespace EnergyDrinks.Pages
{
    public class AddDrinkModel : PageModel
    {
        [BindProperty] //get the object information from a form (post method)
        public EnergyDrinksModel TempDrink { get; set; } //instance of Energy Drink Model 

        private readonly IConfiguration _configuration; //instance of IConfiguration class...allows us to read in from config file like appsettings 

        public AddDrinkModel(IConfiguration configuration)
        {
            //constructor code
            _configuration = configuration;
        }


        //nothing on original page load yet
        public void OnGet()
        {
        }

        //this event handles when there is a post event (the submit button, for example, as the form using post method vs. a get method)
        public IActionResult OnPost()
        {
            IActionResult temp; //temp result var

            if (ModelState.IsValid == false)  //what to do if there are errors on page
            {
                temp = Page(); //reload current page
            }

            else
            {
                if (TempDrink is null == false)
                {
                    EnergyDrinksDataAccessLayer factory = new EnergyDrinksDataAccessLayer(_configuration);

                    factory.Create(TempDrink); //runs the Create function to add a record 
                }
                temp = Page(); //reload current page
            }

            return temp;
        }
    }
}
