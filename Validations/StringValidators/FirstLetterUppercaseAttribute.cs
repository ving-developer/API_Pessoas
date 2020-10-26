using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pessoas.Validations
{
    public class FirstLetterUppercaseAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                var primeiraLetra = value.ToString()[0].ToString();
                if (primeiraLetra != primeiraLetra.ToUpper())
                {
                    return new ValidationResult($"O nome {value.ToString()} não é válido, a primeira letra deve ser maiúscula!");
                }
            }

            return ValidationResult.Success;
        }
    }
}
