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
            Openings = new List<Opening>();
            Comments = new List<Comment>();

        }

        public virtual string Name { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual string Description { get; set; }
        public virtual User User { get; set; }
        public virtual Platform Platform { get; set; }
        public virtual string GitHubName { get; set; }
        public virtual IList<Image> Images { get; set; }
        public virtual IList<Collaborator> Collaborators { get; set; }
        public virtual IList<Opening> Openings { get; set; }
        public virtual IList<Application> Applications { get; set; }
        public virtual IList<Comment> Comments { get; set; }
    }


}