using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectX.Model.Interfaces;
using ProjectX.Model.Entities;
using ProjectX.Models;
using ProjectX.Helpers;

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

        public ActionResult AcceptApplication(int id)
        {
            var application = _dataRepository.Get<Application>(id);

            var project = _dataRepository.Get<Project>(application.Project.Id);
            var test = application.Role;
            project.Collaborators.Add(new Collaborator { User = application.User, Role = (Role)application.Role });
            Opening OpeningToDelete = _dataRepository.FilterBy<Opening>(x => x.Role == application.Role).First();
            project.Openings.Remove(OpeningToDelete);
            //project.Openings.Remove((Opening)OpeningToDelete);

            var AcceptPm = new PrivateMessage { Header = string.Format("Application for {0} accepted", application.Project.Name), Reciever = application.User, IsRead = false, Sent = DateTime.Now, Sender = application.Project.User, Message = string.Format("You are now a part of the {0} project, good luck", application.Project.Name ) };
            _dataRepository.Save<PrivateMessage>(AcceptPm);
            _dataRepository.Delete<Opening>(OpeningToDelete);
            _dataRepository.Update<Project>(application.Project);
            _dataRepository.Delete<Application>(application);

            return RedirectToAction("Index");
        }

        public ActionResult DenyApplication(int id)
        {
            var application = _dataRepository.Get<Application>(id);

            var denyPM = new PrivateMessage { Header = string.Format("Application for {0} denied", application.Project.Name), Reciever = application.User, IsRead = false, Sent = DateTime.Now, Sender = application.Project.User, Message = string.Format("Your application for this project has been denied.", application.Project.Name) };

            _dataRepository.Delete<Application>(application);
            _dataRepository.Save<PrivateMessage>(denyPM);
            return RedirectToAction("Index");
        }

        public ActionResult ApplyForOpening(int id)
        {
            List<Project> projects = new List<Project>();
            var project = _dataRepository.Get<Project>(id);
            projects.Add(project);
            return View(new ApplicationViewModel { Projects = projects });
        }

        [HttpPost]
        public ActionResult ApplyForOpening(Application app, int id)
        {

            var project = _dataRepository.Get<Project>(id);

            var test = _dataRepository.Save<Application>(new Application
            {
                Role = app.Role,
                User = _dataRepository.Get<User>(int.Parse(User.Identity.Name)),
                Message = app.Message,
                Sent = DateTime.Now,
                Project = project  
                
            });



            return View("../Home/Index");
        }

    }
}
