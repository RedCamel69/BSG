using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BSG.WebUI.Models
{
    public class CoachViewModel
    {
        
        public string ID { get; set; }
        
        [DisplayAttribute(Name ="First Name")]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Range(1,2)]
        public int? TemplateId { get; set; }
        public string Image1Name { get; set; }
        public string Image1Path { get; set; }

        public string Address_AddressLine1 { get; set; }
        public string Address_AddressLine2 { get; set; }
        public string Address_AddressLine3 { get; set; }
        public string Address_City { get; set; }
        public string Address_County { get; set; }
        public string Address_PostalCode { get; set; }
        public string Address_Country { get; set; }

        public bool Subscriber { get; set; }
        public Nullable<System.DateTime> SubscriptionEnd { get; set; }

    }

   
}