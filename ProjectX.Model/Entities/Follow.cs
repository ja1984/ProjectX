using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectX.Model.Entities
{
   public class Follow : Entity
    {
        public virtual Project Project { get; set; }
        public virtual User User { get; set;}
    }
}
