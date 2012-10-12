using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectX.Model.Interfaces;
using ProjectX.Model.Entities;

namespace ProjectX.Controllers
{
    public class MessageController : Controller
    {
        private readonly IDataRepository _dataRepository;

        public MessageController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        //
        // GET: /Message/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PrivateMessage pm, int id)
        {

            var sender = _dataRepository.Get<User>(int.Parse(User.Identity.Name));
            var receiver = _dataRepository.Get<User>(id);
            var message = _dataRepository.Save<PrivateMessage>(new PrivateMessage
            {
                IsRead = false,
                Message = pm.Message,
                Sender = sender,
                Reciever = receiver,
                Header = pm.Header,
                Sent = DateTime.Now
            });
            return View("../home/index");
        }

        public JsonResult MarkAsRead(int messageId)
        {
            var message = _dataRepository.Get<PrivateMessage>(messageId);
            message.IsRead = true;
            _dataRepository.Update<PrivateMessage>(message);

            return Json(new { Header = message.Header, Sent = message.Sent.ToString(), Message = message.Message });
        }
    }
}
