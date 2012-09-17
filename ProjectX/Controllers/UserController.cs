using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectX.Models;
using ProjectX.Helpers;
using ProjectX.Repository;

namespace ProjectX.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id, string userName)
        {
            var user = userRepository.Get(id);

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


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegisterModel userRegisterModel)
        {
            if (!ModelState.IsValid)
                return View();


            var id = userRepository.Add(new User
                   {
                       UserName = userRegisterModel.UserName,
                       FirstName = userRegisterModel.FirstName,
                       LastName = userRegisterModel.LastName,
                       Email = userRegisterModel.Email,
                       GravatarEmail = userRegisterModel.GravatarEmail ?? userRegisterModel.Email,
                       Password = userRegisterModel.Password,
                       Salt = string.Empty,
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
