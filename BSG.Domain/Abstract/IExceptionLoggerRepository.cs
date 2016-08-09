using BSG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.Domain.Abstract
{
    public interface IExceptionLoggerRepository
    {
        IEnumerable<ExceptionLogger> LoggedExceptions { get; }

        ExceptionLogger GetExceptionById(int Id);

        void Save(ExceptionLogger e);
    }
}
