using BSG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.Domain.Abstract
{
    public interface ICoachRepository
    {
        IEnumerable<Coach> Coaches { get; }

        Coach GetCoachById(string userId);

        Coach GetCoach(string firstName, string secondName); 

        void Save(Coach c);
    }
}
