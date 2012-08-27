using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectX.Helpers;

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

        public string Image(ProfileImageSize imageSize)
        {

            return new MemberHelper().GetGravatar(GravatarEmail, imageSize);
        }
    }

    public enum ProfileImageSize
    {
        Small = 30,
        Normal = 40,
        Large = 80,
        Extreme = 280
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