using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CapstoneProject.Models
{
    public class MatchingMonth: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var client = (Client)validationContext.ObjectInstance;
            var admin = (AdminTime)validationContext.ObjectInstance;
            if (client.AvailableDate == null)
            {
                return new ValidationResult("Available Date is Required.");
            }

            if(client.AvailableDate.Month != admin.AdminDate.Month)
            {
                return new ValidationResult("This month is not available. You can only choose the chosen month.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}