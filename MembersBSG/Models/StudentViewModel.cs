using BSG.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSG.WebUI.Models
{
    public class StudentViewModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        
       public List<Resource> Resources { get; set; }
    }
}