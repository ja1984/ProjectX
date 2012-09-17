using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectX.Helpers;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProjectX.Models
{
    public class Member
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GravatarEmail { get; set; }
        public string GitHubUserName { get; set; }
        public bool DisplayEmail { get; set; }
        public DateTime Joined { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }

        public string Image(ProfileImageSize imageSize)
        {
            //return new MemberHelper().GetGravatar(GravatarEmail, imageSize);
            return HelperService.GetGravatar(GravatarEmail, imageSize);
        }
        private string _displayName;
        public string DisplayName
        {
            get
            {
                return !string.IsNullOrEmpty(_displayName) ? _displayName : UserName;
            }
            set
            {
                _displayName = value;
            }
        }

        public Member GetFakeMember()
        {
            return new Member
            {
                DisplayEmail = true,
                DisplayName = "Jonathan Andersson",
                Email = "ja1984@gmail.com",
                FirstName = "Jonathan",
                LastName = "Andersson",
                GravatarEmail = "ja1984@gmail.com",
                UserName = "ja1984",
                Id = 1
            };
        }
    }

    public enum ProfileImageSize
    {
        Small = 20,
        Normal = 40,
        Large = 80,
        Extreme = 280
    }

    public class MemberRegisterModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Gravatar email address")]
        public string GravatarEmail { get; set; }

        [Display(Name = "Github username")]
        public string GitHubUserName { get; set; }
        
        [Display(Name="Display my email")]
        public bool DisplayEmail { get; set; }
    }

    public class MemberViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string GravatarEmail { get; set; }
        public string GitHubUserName { get; set; }
        public bool DisplayEmail { get; set; }
        public DateTime Joined { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
    }

}