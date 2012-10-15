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
            Followers = new List<Follow>();
            Updates = new List<Update>();
        }

        public virtual string Name { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual string Description { get; set; }
        public virtual User User { get; set; }
        public virtual Platform Platform { get; set; }
        public virtual Language Language { get; set; }
        public virtual string GitHubName { get; set; }
        public virtual string DownloadLink { get; set; }
        public virtual IList<Image> Images { get; set; }
        public virtual IList<Collaborator> Collaborators { get; set; }
        public virtual IList<Opening> Openings { get; set; }
        public virtual IList<Application> Applications { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public virtual IList<Follow> Followers { get; set; }
        public virtual IList<Update> Updates { get; set; }
    }


}