﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectX.Model.Entities
{
    public class User : Entity
    {

        public User()
        {
        }

        public virtual string UserName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string GravatarEmail { get; set; }
        public virtual string Password { get; set; }
        public virtual string Salt { get; set; }
        public virtual string GitHub { get; set; }
        public virtual bool DisplayEmail { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual int Role { get; set; }
        public virtual string Description { get; set; }
        public virtual Project Project { get; set; }


        //public string Image(ProfileImageSize imageSize)
        //{
        //    return HelperService.GetGravatar(GravatarEmail, imageSize);
        //}
    }

    public enum ProfileImageSize
    {
        Small = 20,
        Normal = 40,
        Large = 80,
        Extreme = 280
    }

    //public class UserRegisterModel
    //{
    //    [Required]
    //    public string Email { get; set; }


    //    [Required]
    //    [Display(Name = "Username")]
    //    public string UserName { get; set; }

    //    [Required]
    //    public string Password { get; set; }

    //    [Required]
    //    [Display(Name = "First name")]
    //    public string FirstName { get; set; }

    //    [Required]
    //    [Display(Name = "Last name")]
    //    public string LastName { get; set; }

    //    [Display(Name = "Gravatar email address")]
    //    public string GravatarEmail { get; set; }

    //    [Display(Name = "Github username")]
    //    public string GitHubUserName { get; set; }

    //    [Display(Name = "Display my email")]
    //    public bool DisplayEmail { get; set; }

    //    public int Role { get; set; }
    //}

    //public class UserViewModel
    //{
    //    public string Email { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string UserName { get; set; }
    //    public string DisplayName { get; set; }
    //    public string GravatarEmail { get; set; }
    //    public string GitHubUserName { get; set; }
    //    public bool DisplayEmail { get; set; }
    //    public DateTime Joined { get; set; }
    //    public int Id { get; set; }
    //    public string Description { get; set; }
    //}

    //public class UserLoginModel
    //{
    //    [Required]
    //    public string Username { get; set; }

    //    [Required]
    //    public string Password { get; set; }
    //}

}