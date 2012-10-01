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


        public JsonResult MarkAsRead(int messageId)
        {
            var message = _dataRepository.Get<PrivateMessage>(messageId);
            message.IsRead = true;
            _dataRepository.Update<PrivateMessage>(message);

            return Json(new { Header = message.Header, Sent = message.Sent.ToString(), Message = message.Message });
        }
    }
}
