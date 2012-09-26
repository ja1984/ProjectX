using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectX.Model.Entities
{
    public class Application : Entity
    {

        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
        public virtual int Role { get; set; }
        public virtual string Message { get; set; }
        public virtual DateTime Sent { get; set; }

    }
}
