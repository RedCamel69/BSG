using BSG.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSG.Domain.Entities;

namespace BSG.Domain.Concrete
{
    public class EFCoachRepository : ICoachRepository
    {
        private BSGEliteEntities1 context = new BSGEliteEntities1();

        public IEnumerable<Coach> Coaches
        {

            

            get {

                var list = context.AspNetRoles.ToList();

                List<Coach> coaches = new List<Coach>();

                foreach (var x in context.AspNetUsers)
                {
                    coaches.Add(new Coach()
                    {
                        Email = x.Email
                    });
                }

                return coaches;
                }

            //get { return context.AspNetUsers; }
        
        }

        public Coach GetCoach(string firstName, string secondName)
        {
            var aspNetUserFromDb = context.AspNetUsers.First(x => x.FirstName == firstName && x.SecondName==secondName);

            Coach coach = new Coach()
            {
                FirstName = aspNetUserFromDb.FirstName,
                SecondName = aspNetUserFromDb.SecondName,
                Address_AddressLine1 = aspNetUserFromDb.Address_AddressLine1,
                Address_AddressLine2 = aspNetUserFromDb.Address_AddressLine2,
                Address_AddressLine3 = aspNetUserFromDb.Address_AddressLine3,
                Address_City = aspNetUserFromDb.Address_City,
                Address_Country = aspNetUserFromDb.Address_Country,
                Address_County = aspNetUserFromDb.Address_County,
                Address_PostalCode = aspNetUserFromDb.Address_PostalCode,
                Email = aspNetUserFromDb.Email,
                PhoneNumber = aspNetUserFromDb.PhoneNumber,
                TemplateID = aspNetUserFromDb.TemplateID,
                ProfileImage = aspNetUserFromDb.ProfileImage
            };
            return coach;
        }

        public Coach GetCoachById(string userId)
        {
            var aspNetUserFromDb = context.AspNetUsers.First(x => x.Id == userId);

            Coach coach = new Coach() {
                FirstName = aspNetUserFromDb.FirstName,
                SecondName = aspNetUserFromDb.SecondName,
                 Address_AddressLine1 = aspNetUserFromDb.Address_AddressLine1,
                 Address_AddressLine2 = aspNetUserFromDb.Address_AddressLine2,
                 Address_AddressLine3 = aspNetUserFromDb.Address_AddressLine3,
                  Address_City=aspNetUserFromDb.Address_City,
                  Address_Country=aspNetUserFromDb.Address_Country,
                  Address_County=aspNetUserFromDb.Address_County,
                  Address_PostalCode=aspNetUserFromDb.Address_PostalCode,
                  Email=aspNetUserFromDb.Email,
                  PhoneNumber = aspNetUserFromDb.PhoneNumber,
                  TemplateID=aspNetUserFromDb.TemplateID,
                  ProfileImage=aspNetUserFromDb.ProfileImage
            };
            return coach;
        }

        public void Save(Coach coach)
        {
            var target = context.AspNetUsers.Where(x => x.Id == coach.Id).FirstOrDefault();
            target.FirstName = coach.FirstName;
            target.SecondName = coach.SecondName;
            target.Email = coach.Email;
            target.PhoneNumber = coach.PhoneNumber;
            target.TemplateID = coach.TemplateID;
            target.ProfileImage = coach.ProfileImage;
            

            context.SaveChanges();
        }
    }
}
