using BSG.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSG.Domain.Entities;

namespace BSG.Domain.Concrete
{
    public class EFStudentRepository : IStudentRepository
    {
        private BSGEliteEntities1 context = new BSGEliteEntities1();

        public IEnumerable<AspNetUser> Students
        {
            get { return context.AspNetUsers; }
        
        }

        public AspNetUser GetStudentById(string userId)
        {

            return context.AspNetUsers.First(x => x.Id == userId);
        }
    }
}
