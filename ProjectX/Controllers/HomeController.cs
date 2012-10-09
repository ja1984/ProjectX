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

            //var userId = int.Parse(User.Identity.Name);
            //var sender = _dataRepository.Get<User>(userId);
            //var reciever = _dataRepository.Get<User>(102);

            //var pm = new PrivateMessage
            //{

            //    Header = "test",
            //    Message = "Hejsan hoppsan",
            //    IsRead = false,
            //    Sent = DateTime.Now,
            //    Sender = reciever,
            //    Reciever = sender
            //};

            //_dataRepository.Save<PrivateMessage>(pm);


            return View();
        }

    }




}
