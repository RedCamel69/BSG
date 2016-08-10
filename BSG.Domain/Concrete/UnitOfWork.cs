using BSG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.Domain.Concrete
{
    public class UnitOfWork : IDisposable
    {
        private BSGEliteEntities1 context = new BSGEliteEntities1();
        private GenericRepository<Coach> coachRepository;
        private GenericRepository<Student> studentRepository;

        public GenericRepository<Coach> CoachRepository
        {
            get
            {

                if (this.coachRepository == null)
                {
                    this.coachRepository = new GenericRepository<Coach>(context);
                }
                return coachRepository;
            }
        }

        public GenericRepository<Student> StudentRepository
        {
            get
            {

                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(context);
                }
                return studentRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
