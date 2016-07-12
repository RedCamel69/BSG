using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using PluginBlog.Core;
using PluginBlog.Core.Entities;
using PluginBlog.Core.Repositories;
using BSG.WebUI.Helpers;

namespace BSG.WebUI.Controllers
{
   
    public class BlogController : Controller
    {
        private readonly IBlogRepository _repository;
        private const int PageSize = 10;

        private string conn = String.Empty;

        public BlogController()
        {
            _repository = new BlogRepository(new BlogContext());

            conn = new BlogContext().Database.Connection.ConnectionString;
        }

        public BlogController(IBlogRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index(int? page)
        {

           // return Content(conn);

            

            var result = _repository.Posts().OrderByDescending(x => x.PostedOn).Take(PageSize);
            var model = new PaginatedList<Post>(result, page ?? 0, PageSize);
            return View(model);
            
        }

        public ActionResult Details(int year, int month, string title)
        {
            var model = _repository.Post(year, month, title);

            if (model == null)
                throw new HttpException(404, "Post not found");
            return View(model);
        }

        public ActionResult Category(int? page, string urlSlug)
        {
            var result = _repository.PostsForCategory(urlSlug).OrderByDescending(x=>x.PostedOn);
            var model = new PaginatedList<Post>(result, page ?? 0, PageSize);
            return View("Index", model);
        }

        public ActionResult Tag(int? page, string urlSlug)
        {
            var result = _repository.PostsForTag(urlSlug).OrderByDescending(x => x.PostedOn); ;
            var model = new PaginatedList<Post>(result, page ?? 0, PageSize);
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult Search(int? page, string searchText)
        {
            var result = _repository.PostsForSearch(searchText).OrderByDescending(x => x.PostedOn); ;
            var model = new PaginatedList<Post>(result, page ?? 0, PageSize);
            return View("Index", model);
        }

       /// <summary>
        /// Generate and return RSS feed.
        /// </summary>
        /// <returns></returns>
        public ActionResult Feed()
        {
            var blogTitle = "A blog about stuff";
            var blogDescription = "A blog about random stuff, add some description here.";
            var blogUrl = "http://www.aboutstuffblog.com";


            var posts = _repository.Posts().Take(20).ToList().Select
            (
                p => new SyndicationItem
                    (
                        p.Title,
                        p.Description,
                        new Uri(string.Concat(blogUrl, Url.PostLink(p)))
                    )
            );

            var feed = new SyndicationFeed(blogTitle, blogDescription, new Uri(blogUrl), posts)
            {
                Copyright = new TextSyndicationContent(String.Format("Copyright © {0}", blogTitle)),
                Language = "en-GB"
            };

            return new FeedResult(new Rss20FeedFormatter(feed));
        }

	}
}