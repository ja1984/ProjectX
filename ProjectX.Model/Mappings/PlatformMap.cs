using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectX.Model.Entities;

namespace ProjectX.Model.Mappings
{
    class PlatformMap : EntityMap<Platform>
    {
        public PlatformMap()
        {
            Map(x => x.Name);
        }
    }
}
