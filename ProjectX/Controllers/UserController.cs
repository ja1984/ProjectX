using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectX.Models;
using ProjectX.Helpers;
using System.Web.Security;
using ProjectX.Model.Interfaces;
using ProjectX.Model.Entities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net;
using System.Drawing;
using EO.Pdf;
using EO.Pdf.Acm;
using EO.Pdf.Contents;
using EO.Pdf.Drawing;
using MoreLinq;




namespace ProjectX.Controllers
{
    public class UserController : Controller
    {

        private readonly IDataRepository _dataRepository;

        public UserController()
        {

        }

        public UserController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        //
        // GET: /User/

        [ChildActionOnly]
        public PartialViewResult UserBar()
        {
            var userId = int.Parse(User.Identity.Name);
            var user = _dataRepository.Get<User>(userId);
            var myApplications = _dataRepository.FilterBy<Application>(x => x.User.Id == userId).Count();
            var myPrivateMessages = _dataRepository.FilterBy<PrivateMessage>(x => x.Reciever.Id == userId && !x.IsRead).Count();

            var totalNotifications = myPrivateMessages + myApplications;

            return PartialView(new UserBarViewModel { TotalNotifications = totalNotifications, ApplicationNotifications = myApplications, MessagesNotifications = myPrivateMessages, User = new UserViewModel { DisplayName = user.DisplayName, GravatarEmail = user.GravatarEmail } });
        }

        public ActionResult Index()
        {
            return View(_dataRepository.All<User>());
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginModel login)
        {
            if (ModelState.IsValid)
            {
                var user = _dataRepository.FilterBy<User>(x => x.UserName == login.Username || x.Email == login.Username).FirstOrDefault();

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "");
                    return View();
                }

                if (HelperService.GenerateHash(HelperService.GenerateSalt(user.UserName), login.Password) == user.Password)
                {
                    FormsAuthentication.SetAuthCookie(user.Id.ToString(), true);
                    return RedirectToAction("Index", "Home");
                }

            }

            ModelState.AddModelError(string.Empty, "");
            return View();
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");

        }


        public ActionResult Details(int id, string userName)
        {
            var user = _dataRepository.Get<User>(id);
            var projects = new List<Project>();

            //Get my projects
            projects.AddRange(_dataRepository.FilterBy<Project>(x => x.User.Id == user.Id).ToList());

            //Get all the projects where I'm a collaborator
            projects.AddRange(_dataRepository.FilterBy<Project>(x => x.Collaborators.Any(z => z.User.Id == user.Id)).ToList());

            var userViewModel = new UserViewModel
            {
                DisplayEmail = user.DisplayEmail,
                DisplayName = user.DisplayName,
                Email = user.Email,
                FirstName = user.FirstName,
                GitHubUserName = user.GitHub,
                GravatarEmail = user.GravatarEmail,
                Joined = user.Created,
                LastName = user.LastName,
                Id = user.Id,
                Role = user.Role,
                Projects = projects.DistinctBy(x => x.Id).ToList()
            };

            string expectedName = HelperService.GenerateSlug(user.UserName);
            string actualName = (userName ?? "").ToLower();

            // permanently redirect to the correct URL
            if (expectedName != actualName)
            {
                return RedirectToActionPermanent("details", "user", new { id = user.Id, userName = expectedName });
            }

            return View(userViewModel);
        }


        public ActionResult Messages()
        {
            var userId = int.Parse(User.Identity.Name);
            var messages = _dataRepository.FilterBy<PrivateMessage>(x => x.Reciever.Id == userId).ToList();
            return View(messages);
        }


        public JsonResult GetMessages()
        {
            var userId = int.Parse(User.Identity.Name);
            var messages = _dataRepository.FilterBy<PrivateMessage>(x => x.Reciever.Id == userId).ToList();
            return Json(messages.Select(x => new { Id = x.Id, Header = x.Header, Message = x.Message, isRead = x.IsRead, Sent = x.Sent.ToShortDateString(), Sender = new { Id = x.Sender.Id, DisplayName = x.Sender.DisplayName } }));
        }


        public JsonResult GetNotifications()
        {
            var userId = int.Parse(User.Identity.Name);
            var user = _dataRepository.Get<User>(userId);
            var projets = _dataRepository.FilterBy<Project>(x => x.User.Id == userId).ToList();
            var ApplicationNotifications = projets.SelectMany(x => x.Applications).Count();
            var privateMessages = _dataRepository.FilterBy<PrivateMessage>(x => x.Reciever.Id == userId && !x.IsRead).Count();

            return Json(new { MessageNotifications = privateMessages, ApplicationNotifications = ApplicationNotifications });
        }


        public ActionResult Register()
        {
            ViewBag.Roles =_dataRepository.All<Role>().ToList();
            
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegisterModel userRegisterModel)
        {
            if (!ModelState.IsValid)
                return View();


            var salt = HelperService.GenerateSalt(userRegisterModel.UserName);

            var role = _dataRepository.Get<Role>(userRegisterModel.RoleId);

            var id = _dataRepository.Save<User>(new User
            {
                UserName = userRegisterModel.UserName,
                FirstName = userRegisterModel.FirstName,
                LastName = userRegisterModel.LastName,
                Email = userRegisterModel.Email,
                GravatarEmail = userRegisterModel.GravatarEmail ?? userRegisterModel.Email,
                Password = HelperService.GenerateHash(salt, userRegisterModel.Password),
                Salt = salt,
                GitHub = userRegisterModel.GitHubUserName,
                Created = DateTime.Now,
                Role = role,
                DisplayEmail = userRegisterModel.DisplayEmail,
                Description = string.Empty,
                DisplayName = string.Concat(userRegisterModel.FirstName, " ", userRegisterModel.LastName)
            });



            return View();
        }


        public ActionResult createPDF(int id)
        {
            User u = _dataRepository.Get<User>(id);


            //WORKS, COSTS MONEY
            //var path = Server.MapPath("/PDFs");
            //HtmlToPdf.ConvertUrl("http://localhost:12832/user/101/ja1984", path + string.Format("/{0}.pdf", u.UserName));

            return RedirectToAction("Index");
        }

        public string Rebuild()
        {
            var developer = new Role { Name = "Developer" };
            var designer = new Role { Name = "Designer" };
            var tester = new Role { Name = "Tester" };


            //Add the roles
            _dataRepository.Save(developer);
            _dataRepository.Save(designer);
            _dataRepository.Save(tester);

            //Add the platforms
            _dataRepository.Save(new Platform() { Name = "Mobile" });
            _dataRepository.Save(new Platform() { Name = "Web" });
            _dataRepository.Save(new Platform() { Name = "Desktop" });
            _dataRepository.Save(new Platform() { Name = "Multi" });


            //Add the languages
            _dataRepository.Save(new Language() { Name = "ActionScript" });
            _dataRepository.Save(new Language() { Name = "C" });
            _dataRepository.Save(new Language() { Name = "C++" });
            _dataRepository.Save(new Language() { Name = "C#" });
            _dataRepository.Save(new Language() { Name = "Object-C" });
            _dataRepository.Save(new Language() { Name = "Java" });


            //Add some users
            var salt1 = HelperService.GenerateSalt("ja1984");
            _dataRepository.Save(new User()
            {
                Created = DateTime.Now,
                Description = "asdasd",
                DisplayEmail = true,
                DisplayName = "Jonathan Andersson",
                Email = "ja1984@gmail.com",
                FirstName = "Jonathan",
                GitHub = "ja1984",
                GravatarEmail = "ja1984@gmail.com",
                LastName = "Andersson",
                Password = HelperService.GenerateHash(salt1, "jonis"),
                Role = developer,
                Salt = salt1,
                UserName = "ja1984"
            });

            var salt2 = HelperService.GenerateSalt("meskHest");
            _dataRepository.Save(new User()
            {
                Created = DateTime.Now,
                Description = "asdasd",
                DisplayEmail = true,
                DisplayName = "Fredrik Olsson",
                Email = "fredrik@mrolsson.se",
                FirstName = "Fredrik",
                GitHub = "meskHest",
                GravatarEmail = "fredrik@mrolsson.se",
                LastName = "Olsson",
                Password = HelperService.GenerateHash(salt2, "fredde"),
                Role = developer,
                Salt = salt2,
                UserName = "meskHest"
            });

            var salt3 = HelperService.GenerateSalt("test");
            _dataRepository.Save(new User()
            {
                Created = DateTime.Now,
                Description = "asdasd",
                DisplayEmail = true,
                DisplayName = "Test Testsson",
                Email = "test@test.com",
                FirstName = "Test",
                GitHub = "test",
                GravatarEmail = "test@test.com",
                LastName = "Testsson",
                Password = HelperService.GenerateHash(salt3, "test"),
                Role = developer,
                Salt = salt3,
                UserName = "test"
            });



            return "Done";
        }
    }
}
