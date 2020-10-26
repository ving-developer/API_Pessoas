using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pessoas.Validations.DateValidators
{
    public class DateLessHigherCurrentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                DateTime now = DateTime.Now;
                if ((DateTime)value < now)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult($"A data {value} não pode ser superior ou igual à {now}");
            }

            return ValidationResult.Success;
        }
    }
}
