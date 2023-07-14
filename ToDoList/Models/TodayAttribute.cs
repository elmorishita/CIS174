using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class TodayAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext ctx)
        {
            if(value is DateTime)
            {
                DateTime dateToCheck = (DateTime)value;
                if(dateToCheck >= DateTime.Today)
                {
                    return ValidationResult.Success!;
                }
            }

            // The ToString("d") causes DateTime to use the shorter version of the date (MM/DD/YYYY)
            string msg = base.ErrorMessage ?? $"Please enter a {ctx.DisplayName} that's greater or equal to today (" + DateTime.Today.ToString("d") + ")";
            return new ValidationResult(msg);
        }
    }
}
