using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectX.Models
{
    public class Member
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string GravatarEmail { get; set; }
        public string GitHubUserName { get; set; }
        public bool DisplayEmail { get; set; }
        public DateTime Joined { get; set; }

    }

    public class MemberRegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GravatarEmail { get; set; }
        public string GitHubUserName { get; set; }
        public bool DisplayEmail { get; set; }
    }

    public class MemberViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string GravatarEmail { get; set; }
        public string GitHubUserName { get; set; }
        public bool DisplayEmail { get; set; }
        public DateTime Joined { get; set; }
    }

}