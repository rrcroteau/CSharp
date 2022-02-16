using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyDrinks.Models
{
    public class EnergyDrinkModel
    {
        public int Drink_ID { get; set; } //Primary Key, Identity Spec

        public string Mfr { get; set; } //name of drink manufacturer

        public string Name { get; set; } //name of the drink

        public string Flavor { get; set; } //drink flavor

        public double Size { get; set; } //size of drink 

        public double Price { get; set; } //price of drink

        public string Support_Email { get; set; } //customer support email for the drink manufacturer


        public DateTime Release_Date { get; set; } //date drink was released

        public bool Active { get; set; } //is the drink still in production (true - yes ; false - no) 


    }
}
