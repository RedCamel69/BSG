using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MembersBSG.HtmlHelpers.PhoneNumberValidation
{
    public class ExcludeRadioTVDramaNumbers : BaseTelephoneValidationAttribute //ValidationAttribute, IClientValidatable
    {
        //http://stakeholders.ofcom.org.uk/telecoms/numbering/guidance-tele-no/numbers-for-drama

        public ExcludeRadioTVDramaNumbers()
        //: base("Number is an Ofcom reserved number for TV / Radio.")
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("^(0113|0114|0115|0116|0117|0118|0121|0131|0141|0151|0161)(4960)[0-9]{3}$"); //various Geographic locations
            builder.Append("|");
            builder.Append("^02079460[0-9]{3}$");
            builder.Append("|");
            builder.Append("^01914980[0-9]{3}$");
            builder.Append("|");
            builder.Append("^02890180[0-9]{3}$");
            builder.Append("|");

            builder.Append("^01632960[0-9]{3}$");
            builder.Append("|");
            builder.Append("^07700900[0-9]{3}$"); //Mobile
            builder.Append("|");
            builder.Append("^08081570[0-9]{3}$"); //Freephone
            builder.Append("|");
            builder.Append("^09098790[0-9]{3}$"); //Premium Rate Service
            builder.Append("|");
            builder.Append("^03069990[0-9]{3}$"); //UK Wide

            expressions = builder.ToString();
        }
    }
}