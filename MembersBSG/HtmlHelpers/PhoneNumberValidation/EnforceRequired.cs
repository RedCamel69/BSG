using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MembersBSG.HtmlHelpers.PhoneNumberValidation
{
    public class EnforceRequired : BaseTelephoneValidationAttribute
    {
        public EnforceRequired() //: base("")
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value == null)
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errorMessage);
            }

            var phoneNumber = RemoveHyphens(RemoveSpaces(value.ToString()));

            if (phoneNumber.Length == 0)
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errorMessage);
            }


            return ValidationResult.Success;
        }
    }
}