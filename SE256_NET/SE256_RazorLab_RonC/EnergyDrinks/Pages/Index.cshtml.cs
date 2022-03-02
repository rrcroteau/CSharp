using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//use the models folder to gain access to classes/libraries within
using EnergyDrinks.Models;
//use for IConfiguration
using Microsoft.Extensions.Configuration;

namespace EnergyDrinks.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        private readonly IConfiguration _configuration; //instance of IConfiguration class...allows us to read in from config file like appsettings

        EnergyDrinksDataAccessLayer factory;  //use the "factory" we created in this class for the DB 
        public List<EnergyDrinksModel> Drinks { get; set; }  //the list to hold all the tickets in the db

        //constructor for this page
        public IndexModel(IConfiguration configuration)
        {
            //constructor
            _configuration = configuration;

            factory = new EnergyDrinksDataAccessLayer(_configuration);
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

            Drinks = factory.GetActiveRecords().ToList(); //fill the currently empty list with records
        }
    }
}
