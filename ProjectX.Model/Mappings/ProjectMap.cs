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
            Map(x => x.Description).Length(4001);
            Map(x => x.Name);
            Map(x => x.GitHubName);

            References(x => x.User);
            References(x => x.Platform);
            References(x => x.Language);
            HasMany(x => x.Images);
            HasMany(x => x.Openings).Cascade.All();
            HasMany(x => x.Applications).Cascade.All();
            HasMany(x => x.Comments).Cascade.All();
            HasManyToMany(x => x.Followers).Cascade.All();
            HasManyToMany(x => x.Collaborators).Cascade.All();
        }
    }
}
