﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectX.Models;
using System.Web.Mvc;


namespace ProjectX.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
