using BSG.Domain;
using BSG.Domain.Concrete;
using BSG.Domain.Entities;
using BSG.WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSG.WebUI.Controllers
{
    public class StudentController : Controller
    {
        /// <summary>
        /// Application DB context
        /// </summary>
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        /// <summary>
        /// User manager - attached to application DB context
        /// </summary>
        protected UserManager<ApplicationUser> UserManager { get; set; }


        public StudentController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }

        // GET: Student
        [Authorize(Roles ="Student")]
        public ActionResult Index(ApplicationUser currentUser)
        {

         string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();

            EFStudentRepository rep = new EFStudentRepository();

            AspNetUser s = rep.GetStudentById(UserId);


            StudentViewModel vm = new StudentViewModel();
            vm.FirstName = s.UserName;
            vm.SecondName = s.Id;

            vm.Resources = new List<Domain.Resource>();

            foreach(Domain.Resource r in s.Resources)
            {
                vm.Resources.Add(r);
            }

            return View(vm);
        }
    }
}