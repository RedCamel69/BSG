using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BSG.WebUI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string WebSite { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public bool RegisterNow { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string GolfFacilityName { get; set; }
        public CoachAddress Address { get; set; }
        public string Coach1 { get; set; }
        public string Coach2 { get; set; }
        //public CoachReferral Referral { get; set; }
        public string Referral { get; set; }
        public bool SendUpdates { get; set; }

        public bool Subscriber { get; set; }
        public System.DateTime SubscriptionEnd { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}