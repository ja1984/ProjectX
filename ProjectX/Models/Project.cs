using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectX.Model.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjectX.Models
{
    public class ProjectRegisterModel
    {

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "Project name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "GitHub name")]
        public string GitHubName { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "Please tell potential minions something about the project")]

        public string Description { get; set; }
        [Display(AutoGenerateField = false)]
        public User Creator { get; set; }
    }

}