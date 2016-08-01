using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MembersBSG.HtmlHelpers.PhoneNumberValidation
{
    //http://stakeholders.ofcom.org.uk/consultations/0500-number-range/summary
    //A few old-style freephone numbers starting with 0500 are still in operation, but will be withdrawn during 2017. Newer freephone numbers begin with 080.

    public class ExcludeOFiveHundredRange : BaseTelephoneValidationAttribute
    {
        public ExcludeOFiveHundredRange() //: base("Number has Country Code.")
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"^(0500){1}");
            //builder.Append(" || ");

            expressions = builder.ToString();

        }

    }
}