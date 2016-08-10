using BSG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.Domain.Concrete.Command
{
    //http://rob.conery.io/2014/03/04/repositories-and-unitofwork-are-not-a-good-idea/

    public class CreateNewCoachCommand
    {
        public Coach NewCoach { get; set; }


        //our UNitOfWork
        BSGEliteEntities1 _context;

        public CreateNewCoachCommand(BSGEliteEntities1 context)
        {
            //allow it to be injected - though that's only for testing
            _context = context;
        }

        public Coach Execute()
        {
            //allow for mocking and passing in... otherwise new it up
            _context = _context ?? new BSGEliteEntities1();

           
            

           
            _context.SaveChanges();

            //return newOrder;
            return new Coach();
        }
    }
}
