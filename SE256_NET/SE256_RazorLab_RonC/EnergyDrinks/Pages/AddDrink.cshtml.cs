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
        public EnergyDrinkModel TempDrink { get; set; } //instance of Energy Drink Model 

        public void OnGet()
        {
        }

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
