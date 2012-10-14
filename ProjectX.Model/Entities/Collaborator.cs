using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace ProjectX.Model.Entities
{
    public class Collaborator : Entity
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}