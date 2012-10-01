using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectX.Model.Interfaces;
using ProjectX.Model.Entities;
using ProjectX.Models;

namespace ProjectX.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IDataRepository _dataRepository;

        public ApplicationController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public ActionResult Index()
        {
            var userId = int.Parse(User.Identity.Name);

            var projets = _dataRepository.FilterBy<Project>(x => x.User.Id == userId).ToList();

            var applications = projets.SelectMany(x => x.Applications).ToList();

            return View(applications);
        }


        public ActionResult Details(int id)
        {
            var application = _dataRepository.Get<Application>(id);
            var projects = new List<Project>();

            var userId = application.User.Id;

            projects.AddRange(_dataRepository.FilterBy<Project>(x => x.User.Id == userId).ToList());
            projects.AddRange(_dataRepository.FilterBy<Project>(x => x.Collaborators.Where(z => z.User.Id == userId).Any()).ToList());

            return View(new ApplicationViewModel { Application = application, Projects = projects });
        }

    }
}
