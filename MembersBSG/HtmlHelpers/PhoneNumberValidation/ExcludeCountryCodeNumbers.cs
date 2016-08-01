using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MembersBSG.HtmlHelpers.PhoneNumberValidation
{
    public class ExcludeCountryCodeNumbers : BaseTelephoneValidationAttribute
    {
        public ExcludeCountryCodeNumbers() //: base("Number has Country Code.")
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"^(\+)[\s]*(.*)$");
            //builder.Append(" || ");

            expressions = builder.ToString();
        }

    }
}