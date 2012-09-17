using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace ProjectX.Models
{
    public class Collaborator : Member
    {
        public Role Role { get; set; }
    }


    public enum Role
    {
        Developer,
        Designer,
        Tester
    }

}