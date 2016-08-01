using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace MembersBSG.HtmlHelpers.PhoneNumberValidation
{
    public class EnforceLength : BaseTelephoneValidationAttribute
    {
        public EnforceLength() //: base("")
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"^[0-9]{10,11}$");
            //builder.Append(" || ");

            expressions = builder.ToString();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var phoneNumber = RemoveHyphens(RemoveSpaces(value.ToString()));

            Regex regex = new Regex(expressions);
            phoneNumber = Regex.Replace(phoneNumber, @"\s+", "");
            Match match = regex.Match(phoneNumber);
            if (!match.Success)
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errorMessage);
            }

            return ValidationResult.Success;
        }
    }
}