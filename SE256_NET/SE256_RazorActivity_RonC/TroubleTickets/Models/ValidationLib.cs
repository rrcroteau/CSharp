using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //necessary for Validation attribute
//This is needed for validation purposes (IModelValidator) //
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation; //the second class function will need this

namespace TroubleTickets.Models
{
   
        //create a class to validate dates -- this one will be used to verify a valid date in the past/present
        // <1> take in an object and convert it to a DateTime object
        // <2> if the date is past/present (i.e. less than the date and time the validation occurs) return a Success result
        // <3> this means the date is in the future, so return the error message
        public class MyDateAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                DateTime _dateJoin = Convert.ToDateTime(value); // <1>

                if (_dateJoin <= DateTime.Now) // <2>
                {
                    return ValidationResult.Success;
                }

                else // <3>
                {
                    return new ValidationResult(ErrorMessage); 
                }

            }
        }

        //create a class that receives a list of allowed strings; if the string passed matches a string in the list it passes validation
        // <1> the array of acceptable strings
        // <2> the error message to be returned if the validation fails
        // <3> if the list of allowed words contains the string passed to the function, it passes validation
        // <4> if the validation fails, return the error message
        public class StringOptionsValidate : Attribute, IModelValidator
        {
            public string [] Allowed { get; set; } // <1> 
            public string ErrorMessage { get; set; } // <2>

            public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
            {
                if (Allowed.Contains(context.Model as string)) // <3>
                {
                    return Enumerable.Empty<ModelValidationResult>();
                }

                else  // <4>
                {
                    
                    return new List<ModelValidationResult> { new ModelValidationResult("", ErrorMessage) };
                }
            }
        }




}
