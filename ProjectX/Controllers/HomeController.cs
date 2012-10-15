using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectX.Models;
using System.Web.Mvc;
using ProjectX.Model.Interfaces;
using ProjectX.Model.Entities;


namespace ProjectX.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private readonly IDataRepository _dataRepository;

        public HomeController()
        {
            
        }


        public HomeController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public ActionResult Index()
        {

            if(!string.IsNullOrEmpty(User.Identity.Name)){
                return RedirectToAction("Feed");
            }

            return View();
        }

        public ActionResult Feed()
        {
            var userId = int.Parse(User.Identity.Name);
            var following = _dataRepository.FilterBy<Follow>(x => x.User.Id == userId).ToList();
            var updates = new List<Update>();
            updates.AddRange(following.SelectMany(x=>x.Project.Updates));

            return View(updates);
        }

    }




}
