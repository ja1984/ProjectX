using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectX.Model.Entities
{
    public class Opening : Entity
    {
        public virtual int Role { get; set; }
        public virtual Project Project { get; set; }
    }
}