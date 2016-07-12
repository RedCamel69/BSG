using BSG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.Domain.Abstract
{
    public interface IStudentRepository
    {
        IEnumerable<AspNetUser> Students { get; }

        AspNetUser GetStudentById(string userId); 
    }
}
