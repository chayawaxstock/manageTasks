using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Validations
{
    class ValidDateEndAtribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
           
                //Take userId and email of the user parameter
                DateTime dateBegin = (validationContext.ObjectInstance as Project).DateBegin;
          
                if (dateBegin>= DateTime.Parse(value.ToString()))
                {
                    ErrorMessage = "date end project grate than date begin project";
                    validationResult = new ValidationResult(ErrorMessageString);
                }
           
            return validationResult;
        }

    }
}
