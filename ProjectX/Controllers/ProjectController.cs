using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectX.Models;
using ProjectX.Helpers;

namespace ProjectX.Controllers
{
    public class ProjectController : Controller
    {
        //
        // GET: /Project/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id, string projectName)
        {
            

            var projectViewModel = new ProjectViewModel { Project = new Project().GetFakeProject() };

            string expectedName = HelperService.GenerateSlug(projectViewModel.Project.Name);
            string actualName = (projectName ?? "").ToLower();

            // permanently redirect to the correct URL
            if (expectedName != actualName)
            {
                return RedirectToActionPermanent("details", "project", new { id = projectViewModel.Project.Id, projectName = expectedName });
            }

            return View(projectViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}
