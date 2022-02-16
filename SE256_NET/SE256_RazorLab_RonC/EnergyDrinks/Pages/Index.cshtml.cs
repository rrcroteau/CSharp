using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyDrinks.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //BindProperty connects property with a Post
        //Adding the SupportsGet allows the data to come from the URL (Get/Post)
        [BindProperty(SupportsGet = true)]
        public string FName { get; set; } //first name property with default set/get

        public void OnGet()
        {
            //if the URL doesn't contain an FName value passed , we will set a default
            if (string.IsNullOrWhiteSpace(FName))
            {
                FName = "Energy Drink Enthusiast"; //sets the default value
            }
        }
    }
}
