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

        public HomeController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public ActionResult Index()
        {


            var user = _dataRepository.All<User>().ToList();


            return View();
        }

    }




}
