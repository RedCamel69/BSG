using BSG.Domain.Concrete;
using BSG.Domain.Entities;
using BSG.WebUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSG.WebUI.Controllers
{
    public class CoachController : Controller
    {
        // GET: Coach

        private EFCoachRepository repository;
        private string Id { get; set; }


        public CoachController(EFCoachRepository repo)
        {
            repository = repo;
        }

        [Authorize(Roles ="Coach")]
        public ActionResult Index(string id)
        {
           
            var coach = repository.GetCoachById(id);

            CoachViewModel vm = new CoachViewModel();

            vm.ID = id;
            vm.FirstName = coach.FirstName;
            vm.SecondName = coach.SecondName;
            vm.TemplateId = coach.TemplateID;
            vm.Email = coach.Email;
            vm.Phone = coach.PhoneNumber;
            vm.Image1Name = coach.ProfileImage; //  FirstName + coach.SecondName + ".jpg";
            vm.Image1Path= Server.MapPath("~/content/images/uploads/");

            vm.Image1Path = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "/content/images/uploads/" + coach.ProfileImage;


            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem
            {
                Text = "Select TEmplate",
                Value = "0",
                Selected = true
            });

            items.Add(new SelectListItem
            { Text = "Red", Value = "1" });
            items.Add(new SelectListItem
            { Text = "Blue", Value = "2" });

            ViewData["TemplateType"] = items;

            Session["vm"] = vm;

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(CoachViewModel vm, HttpPostedFileBase Image1)
        {
           Session["vm"] = vm;

            if (Image1 != null && Image1.ContentLength > 0)
            {
                
                //var fileName = Path.GetFileName(Image1.FileName);
                var path = Server.MapPath("~/content/images/uploads");
                //System.IO.File.Delete(path + "/Coach.jpg");
                System.IO.File.Delete(path + "/" + vm.Image1Name);

                /*
                FileInfo temp = new FileInfo(path + "/Coach.jpg");
                if (temp.Exists) temp.Delete();
                */

                Image1.SaveAs(path + "/" + vm.FirstName + vm.SecondName + ".jpg");
                vm.Image1Name = vm.FirstName + vm.SecondName + ".jpg";
            }


            Coach c = new Coach()
            {
                 Id=vm.ID,
                FirstName = vm.FirstName,
                 SecondName=vm.SecondName,
                  Email=vm.Email,
                  PhoneNumber = vm.Phone,
                  TemplateID = vm.TemplateId,
                   ProfileImage=vm.Image1Name
                  
            };

            repository.Save(c);

            return View(vm);
        }

        [Route("BSGCoach/{firstname}/{secondname}")]
        public ActionResult BSGElite(string firstname , string secondname)
        {

            var coach = repository.GetCoachById("3233975d-d96e-49a1-b340-35b96a2d283a");

            CoachViewModel vm = new CoachViewModel();

            vm.ID = coach.Id;
            vm.FirstName = coach.FirstName;
            vm.SecondName = coach.SecondName;
            vm.TemplateId = coach.TemplateID;
            vm.Email = coach.Email;
            vm.Phone = coach.PhoneNumber;
            vm.Image1Name = coach.ProfileImage; //  FirstName + coach.SecondName + ".jpg";
            vm.Image1Path = Server.MapPath("~/content/images/uploads/");

            vm.Image1Path = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "/content/images/uploads/" + coach.ProfileImage;




            return View(vm);
        }
    }
}