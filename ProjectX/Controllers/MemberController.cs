using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectX.Models;
using ProjectX.Helpers;

namespace ProjectX.Controllers
{
    public class MemberController : Controller
    {
        //
        // GET: /Member/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id, string userName)
        {
            var member = new Member().GetFakeMember();

            var memberViewModel = new MemberViewModel
            {
                DisplayEmail = member.DisplayEmail,
                DisplayName = member.DisplayName,
                Email = member.Email,
                FirstName = member.FirstName,
                GitHubUserName = member.GitHubUserName,
                GravatarEmail = member.GravatarEmail,
                Joined = member.Joined,
                LastName = member.LastName,
                Id = member.Id,
            };

            string expectedName = HelperService.GenerateSlug(member.UserName);
            string actualName = (userName ?? "").ToLower();

            // permanently redirect to the correct URL
            if (expectedName != actualName)
            {
                return RedirectToActionPermanent("details", "member", new { id = member.Id, userName = expectedName });
            }

            return View(memberViewModel);
        }


        public ActionResult Register()
        {
            return View();
        }
    }
}
