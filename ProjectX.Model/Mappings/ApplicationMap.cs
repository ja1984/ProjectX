using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectX.Model.Entities;

namespace ProjectX.Model.Mappings
{
    class ApplicationMap : EntityMap<Application>
    {
        public ApplicationMap()
        {
            Map(x => x.Sent);
            Map(x => x.Role);
            Map(x => x.Message).Length(4001);
            References(x => x.Project);
            References(x => x.User);
        }

    }
}
