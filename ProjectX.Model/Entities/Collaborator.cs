using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace ProjectX.Model.Entities
{
    public class Collaborator : User
    {
        public virtual Role Role { get; set; }
    }


    public enum Role
    {
        Developer,
        Designer,
        Tester
    }

}