using BSG.WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BSG.WebUI.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Admin
        [Authorize(Roles ="Admin")]
        public ActionResult Index(AdminViewModel vm)
        {

            
            vm.Coaches = new List<IdentityUser>();
            vm.Students = new List<IdentityUser>();

            var roles = context.Roles.ToList();



            var testRole = context.Roles.First(r => r.Name == "Coach");



            var testerUsers = from u in context.Users

                              where u.Roles.Any(r => r.RoleId == testRole.Id)

                              select u;
            

            foreach (var u in testerUsers)
            {

                // vm.testUsers.Add(new IdentityUser() { UserName = u.UserName });
                vm.Coaches.Add(new IdentityUser() { UserName = u.UserName });

            }


            var studentRole = context.Roles.First(r => r.Name == "Student");



            var studentUsers = from u in context.Users

                              where u.Roles.Any(r => r.RoleId == studentRole.Id)

                              select u;


            foreach (var u in studentUsers)
            {

                // vm.testUsers.Add(new IdentityUser() { UserName = u.UserName });
                vm.Students.Add(new IdentityUser() { UserName = u.UserName });

            }





            return View(vm);
        }
    }
}