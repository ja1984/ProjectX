using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectX.Models;
using ProjectX.Helpers;

namespace ProjectX.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id, string userName)
        {
            var user = new User().GetFakeUser();

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
    }
}
