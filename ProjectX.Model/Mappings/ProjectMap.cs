using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectX.Model.Entities;

namespace ProjectX.Model.Mappings
{
    class ProjectMap : EntityMap<Project>
    {
        public ProjectMap()
        {
            Map(x => x.Created);
            Map(x => x.Description);
            Map(x => x.Name);
            Map(x => x.GitHubName);

            References(x => x.User);
            HasMany(x => x.Images);
            HasMany(x => x.Openings).Cascade.All();
            HasManyToMany(x => x.Collaborators).Cascade.All();
        }
    }
}
