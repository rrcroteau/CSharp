using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //necessary for validation attr
using System.Linq;
using System.Threading.Tasks;
using static EnergyDrinks.Models.ValidationLib;

namespace EnergyDrinks.Models
{
    public class EnergyDrinksModel
    {

        [Required]
        public int Drink_ID { get; set; } //Primary Key, Identity Spec

        [Required(ErrorMessage ="Drink Manufacturer is required"), StringLength(50)]
        public string Mfr { get; set; } //name of drink manufacturer

        [Required(ErrorMessage = "Drink Name is required"), StringLength(50)]
        public string Name { get; set; } //name of the drink

        [Required(ErrorMessage = "Drink Flavor is required"), StringLength(50)]
        public string Flavor { get; set; } //drink flavor

        //this uses ValidationLib class to set an array used for validation and the appropriate error message should the input not be in the list
        [Required(ErrorMessage = "Drink Size is required"),]
        [StringOptionsValidate(Allowed = new string[] { "8", "10", "12", "16", "20" }, ErrorMessage = "Sorry, that is an invalid size choice. Acceptable Sizes: 8, 10, 12, 16, or 20")]
        public string Size { get; set; } //size of drink 

        [Required(ErrorMessage = "Drink Price is required")]
        [RegularExpression(@"\d{1,3}(?:[.,]\d{3})*(?:[.,]\d{2})", ErrorMessage = "Please enter a valid price without the money symbol (i.e. 2.99)")]
        public string Price { get; set; } //price of drink

        [Required(ErrorMessage = "Support Email Address is required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9._%+-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Support_Email { get; set; } //customer support email for the drink manufacturer

        [Required(ErrorMessage ="Please enter a date that is not in the future")]
        [Display(Name = "Original Release Date")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        [MyDate(ErrorMessage = "Future date entry not allowed")]
        public DateTime Release_Date { get; set; } //date drink was released

        [Required]
        public bool Active { get; set; } //is the drink still in production (true - yes ; false - no) 


    }
}
