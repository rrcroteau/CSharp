using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroubleTickets.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        // BindProperty connects property with a Post
        // Adding the SupportsGet allows data to come via URL
        [BindProperty(SupportsGet = true)]
        public String FName { get; set; } //first name with default set/get

        public void OnGet()  /*This is what happens when the page loads without a post event  OnPost vs. OnGet*/
        {
            //if the URL does not have an FName value passed, we will set default
            if (string.IsNullOrWhiteSpace(FName))
            {
                FName = "You!"; //set default value
            }
        }
    }
}
