using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectX.Model.Entities;

namespace ProjectX.Model.Mappings
{
    class RoleMap : EntityMap<Role>
    {
        public RoleMap()
        {
            Map(x => x.Name);
        }
    }
}
