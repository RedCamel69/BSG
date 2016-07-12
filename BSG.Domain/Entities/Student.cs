using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.Domain.Entities
{
    public class Student 
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public  List<Resource> Resources { get; set; }


        public Student()
        {
         
        }
    }
}
