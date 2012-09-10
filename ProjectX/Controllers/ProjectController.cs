using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectX.Models;

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

        public ActionResult Details()
        {
            return View(new ProjectViewModel { Project = new Project().GetFakeProject() });
        }

    }
}
