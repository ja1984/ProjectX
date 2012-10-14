using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectX.Model.Entities;

namespace ProjectX.Model.Mappings
{
    class CollaboratorMap : EntityMap<Collaborator>
    {
        public CollaboratorMap()
        {
            References(x => x.Role);
            References(x => x.User);
        }
    }
}
