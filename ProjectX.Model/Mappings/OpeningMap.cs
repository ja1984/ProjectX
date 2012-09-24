using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectX.Model.Entities;

namespace ProjectX.Model.Mappings
{
    class OpeningMap : EntityMap<Opening>
    {

        public OpeningMap()
        {
            Map(x => x.Role);
            References(x => x.Project);

        }

    }
}
