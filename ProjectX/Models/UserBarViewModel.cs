using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectX.Models
{
    public class UserBarViewModel
    {
        public int ApplicationNotifications { get; set; }
        public int MessagesNotifications { get; set; }
        public int TotalNotifications { get; set; }
        public UserViewModel User { get; set; }

    }
}