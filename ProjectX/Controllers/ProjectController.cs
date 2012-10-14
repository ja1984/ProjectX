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
            ViewBag.Languages = _dataRepository.All<Language>().OrderBy(x => x.Name).ToList();
            ViewBag.Platforms = _dataRepository.All<Platform>().OrderBy(x => x.Name).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Create(ProjectRegisterModel projectRegisterModel, string collaborators)
        {
            List<string> openings = collaborators.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var language = _dataRepository.Get<Language>(projectRegisterModel.LanguageId);
            var platform = _dataRepository.Get<Platform>(projectRegisterModel.PlatFormId);

            var id = _dataRepository.Save<Project>(new Project
            {
                Created = DateTime.Now,
                Description = projectRegisterModel.Description,
                Name = projectRegisterModel.Name,
                GitHubName = projectRegisterModel.GitHubName,
                User = _dataRepository.Get<User>(int.Parse(User.Identity.Name)),
                Platform = platform,
                Language = language,
                Openings = openings.Select(x => new Opening { Role = new Role() { Id = int.Parse(x) } }).ToList()
            });

            return RedirectToAction("Index");
        }
    }
}
