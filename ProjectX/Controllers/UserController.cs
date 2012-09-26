using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectX.Models;
using ProjectX.Helpers;
using System.Web.Security;
using ProjectX.Model.Interfaces;
using ProjectX.Model.Entities;

namespace ProjectX.Controllers
{
    public class UserController : Controller
    {

        private readonly IDataRepository _dataRepository;

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
            var myProjects = _dataRepository.FilterBy<Project>(x => x.User.Id == userId).Count();
            var myPrivateMessages = _dataRepository.FilterBy<PrivateMessage>(x => x.Reciever.Id == userId && !x.IsRead).Count();

            var totalNotifications = myPrivateMessages + myProjects;

            return PartialView(new UserBarViewModel { TotalNotifications = totalNotifications, ApplicationNotifications = myProjects, MessagesNotifications = myPrivateMessages, User = new UserViewModel { DisplayName = user.DisplayName, GravatarEmail = user.GravatarEmail } });
        }

        public ActionResult Index()
        {
            return View();
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

            var userViewModel = new UserViewModel
            {
                DisplayEmail = user.DisplayEmail,
                DisplayName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                GitHubUserName = user.GitHub,
                GravatarEmail = user.GravatarEmail,
                Joined = user.Created,
                LastName = user.LastName,
                Id = user.Id,
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


        public JsonResult GetMessage(int messageId)
        {
            var message = _dataRepository.Get<PrivateMessage>(messageId);

            if (!message.IsRead)
            {
                message.IsRead = true;
                _dataRepository.Update<PrivateMessage>(message);
            }

            return Json(new { Header = message.Header, Sent = message.Sent.ToString(), Message = message.Message });
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegisterModel userRegisterModel)
        {
            if (!ModelState.IsValid)
                return View();


            var salt = HelperService.GenerateSalt(userRegisterModel.UserName);

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
                Role = userRegisterModel.Role,
                DisplayEmail = userRegisterModel.DisplayEmail,
                Description = string.Empty,
                DisplayName = string.Concat(userRegisterModel.FirstName, " ", userRegisterModel.LastName)
            });



            return View();
        }
    }
}
