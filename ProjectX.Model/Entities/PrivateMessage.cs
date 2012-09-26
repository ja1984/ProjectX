using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectX.Model.Entities
{
   public class PrivateMessage : Entity
    {

        public virtual string Header { get; set; }
        public virtual string Message { get; set; }
        public virtual DateTime Sent { get; set; }
        public virtual bool IsRead { get; set; }
        public virtual User Sender { get; set; }
        public virtual User Reciever { get; set; }

    }
}
