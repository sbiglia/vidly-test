using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Dtos;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (validationContext.ObjectInstance is Customer)
            {
                return Check((Customer) validationContext.ObjectInstance);
            }

            if (validationContext.ObjectInstance is CustomerDto)
            {
                return Check((CustomerDto)validationContext.ObjectInstance);
            }

            return new ValidationResult($"{validationContext.MemberName} could not be validated!.");

        }

        private ValidationResult Check(Customer customer)
        {
           
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birth date is required.");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age > 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }

        private ValidationResult Check (CustomerDto customer)
        {

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birth date is required.");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age > 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }
    }
}