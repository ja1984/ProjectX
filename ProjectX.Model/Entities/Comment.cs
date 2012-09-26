using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectX.Model.Entities
{
    public class Comment : Entity
    {

        public virtual string Message { get; set; }
        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
        public virtual DateTime Sent { get; set; }


    }
}
