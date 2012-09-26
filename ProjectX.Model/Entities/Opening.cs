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


        public virtual string GetRole(int roleId)
        {
            string[] roles = new string[] { "Web Developer", "Web Designer", "Tester" };

            return roles[roleId];
        }
    }
}