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
        //private readonly IProjectRepository _projectRepository;
        //private readonly IUserRepository _userRepository;

        //public ProjectController(IProjectRepository projectRepository, IUserRepository userRepository)
        //{
        //    _projectRepository = projectRepository;
        //    _userRepository = userRepository;
        //}


        public ActionResult Index()
        {
            //var projects = _projectRepository.Get().ToList();

            return View();
        }

        public ActionResult Details(int id, string projectName)
        {


            ////var projectViewModel = new ProjectViewModel { Project = new Project().GetFakeProject() };

            //string expectedName = HelperService.GenerateSlug(projectViewModel.Project.Name);
            //string actualName = (projectName ?? "").ToLower();

            //// permanently redirect to the correct URL
            //if (expectedName != actualName)
            //{
            //    return RedirectToActionPermanent("details", "project", new { id = projectViewModel.Project.Id, projectName = expectedName });
            //}

            //return View(projectViewModel);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Create(ProjectRegisterModel projectRegisterModel, string Collaborators)
        //{
        //    //string[] openings = Collaborators.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);


        //    //var id = _projectRepository.Add(new Project
        //    //{
        //    //    Created = DateTime.Now,
        //    //    CreatorId = int.Parse(User.Identity.Name),
        //    //    Description = projectRegisterModel.Description,
        //    //    Name = projectRegisterModel.Name,
        //    //    GitHubName = projectRegisterModel.GitHubName,
        //    //    Creator = _userRepository.Get(int.Parse(User.Identity.Name))
        //    //});


        //    return View();
        //}
    }
}
