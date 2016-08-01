using BSG.Domain.Abstract;
using BSG.WebUI.Models;
using PluginBlog.Core;
using PluginBlog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSG.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IStudentRepository repo;

        public HomeController(IStudentRepository repos)
        {
            repo = repos;
        }

        public ActionResult Index()
        {

            //var students = repo.Students.ToList();

            //var _repository = new BlogRepository(new BlogContext());

            //var model = _repository.Posts().OrderByDescending(x => x.PostedOn).Take(3).ToList();
            //var model = new PaginatedList<Post>(result, page ?? 0, PageSize);

            HomeIndexViewModel vm = new HomeIndexViewModel();
            //vm.Posts = model;


            return View(vm);

            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}