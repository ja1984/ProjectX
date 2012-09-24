using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectX.Models;
using ProjectX.Helpers;
using ProjectX.Model.Interfaces;
using ProjectX.Model.Entities;

namespace ProjectX.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IDataRepository _dataRepository;

        public ProjectController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }


        public ActionResult Index()
        {
            var projects = _dataRepository.All<Project>().ToList();

            return View(projects);
        }

        public ActionResult Details(int id, string projectName)
        {

            var project = _dataRepository.Get<Project>(id);

            string expectedName = HelperService.GenerateSlug(project.Name);
            string actualName = (projectName ?? "").ToLower();

            // permanently redirect to the correct URL
            if (expectedName != actualName)
            {
                return RedirectToActionPermanent("details", "project", new { id = project.Id, projectName = expectedName });
            }

            return View(project);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProjectRegisterModel projectRegisterModel, string Collaborators)
        {
            List<string> openings = Collaborators.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var id = _dataRepository.Save<Project>(new Project
            {
                Created = DateTime.Now,
                Description = projectRegisterModel.Description,
                Name = projectRegisterModel.Name,
                GitHubName = projectRegisterModel.GitHubName,
                User = _dataRepository.Get<User>(int.Parse(User.Identity.Name)),
                Openings = openings.Select(x => new Opening { Role = int.Parse(x) }).ToList()
            });

            return View();
        }
    }
}
