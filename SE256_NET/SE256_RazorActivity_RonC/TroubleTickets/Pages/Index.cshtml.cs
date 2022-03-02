using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//use the models folder to gain access to classes/libraries within
using TroubleTickets.Models;
//use for IConfiguration
using Microsoft.Extensions.Configuration;

namespace TroubleTickets.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        // BindProperty connects property with a Post
        // Adding the SupportsGet allows data to come via URL
        [BindProperty(SupportsGet = true)]
        public String FName { get; set; } //first name with default set/get

        private readonly IConfiguration _configuration; //instance of IConfiguration class...allows us to read in from config file like appsettings

        TroubleTicketDataAccessLayer factory;  //use the "factory" we created in this class for the DB 
        public List<TroubleTicketModel> tix { get; set; }  //the list to hold all the tickets in the db

        //constructor for this page
        public IndexModel(IConfiguration configuration)
        {
            //constructor
            _configuration = configuration;

            factory = new TroubleTicketDataAccessLayer(_configuration);
        }

        public void OnGet()  /*This is what happens when the page loads without a post event  OnPost vs. OnGet*/
        {
            //if the URL does not have an FName value passed, we will set default
            if (string.IsNullOrWhiteSpace(FName))
            {
                FName = "You!"; //set default value
            }

            tix = factory.GetActiveRecords().ToList(); //fill the currently empty list with records
        }
    }
}
