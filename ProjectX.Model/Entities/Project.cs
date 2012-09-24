using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectX.Model.Entities
{

    public class Project : Entity
    {
        public Project()
        {
            Images = new List<Image>();
            Collaborators = new List<Collaborator>();
           // Openings = new List<Opening>();
        }

        public virtual string Name { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual string Description { get; set; }
        public virtual User User { get; set; }
        public virtual string GitHubName { get; set; }
        public virtual IList<Image> Images { get; set; }
        public virtual IList<Collaborator> Collaborators { get; set; }
        //public virtual IList<Opening> Openings { get; set; }
    }

    //public class ProjectRegisterModel
    //{
    //    //public List<Image> Images { get; set; }
    //    //public List<Helper> Helpers { get; set; }

    //    [Required(ErrorMessage = "Field is required")]
    //    [Display(Name = "Project name")]
    //    public string Name { get; set; }

    //    [Required(ErrorMessage = "Field is required")]
    //    [Display(Name = "GitHub name")]
    //    public string GitHubName { get; set; }

    //    [Required(ErrorMessage = "Field is required")]
    //    [Display(Name = "Please tell potential minions something about the project")]

    //    public string Description { get; set; }
    //    [Display(AutoGenerateField = false)]
    //    public User Creator { get; set; }
    //}



    public class ProjectViewModel
    {
        public Project Project { get; set; }
    }
}