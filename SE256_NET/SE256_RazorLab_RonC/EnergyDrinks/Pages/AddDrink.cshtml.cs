using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EnergyDrinks.Models; //included in order to make a temporary energy drink model

namespace EnergyDrinks.Pages
{
    public class AddDrinkModel : PageModel
    {
        [BindProperty] //get the object information from a form (post method)
        public EnergyDrinksModel TempDrink { get; set; } //instance of Energy Drink Model 


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
                temp = Page(); //reload current page
            }

            return temp;
        }
    }
}
