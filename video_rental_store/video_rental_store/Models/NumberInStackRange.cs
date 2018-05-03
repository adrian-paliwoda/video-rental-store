using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;

namespace video_rental_store.Models
{
    public class NumberInStackRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            if (movie.NumberInStock < Movie.MinInStack || movie.NumberInStock > Movie.MaxInStack)
                return new ValidationResult("Numbers in stack should be between 1 and 20.");

            return ValidationResult.Success;
            
        }
    }
}