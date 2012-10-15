using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectX.Model.Entities;

namespace ProjectX.Model.Mappings
{
    class UpdateMap : EntityMap<Update>
    {
        public UpdateMap()
        {
            Map(x => x.Added);
            Map(x => x.Header);
            Map(x => x.Message);

            References(x => x.Author);
        }

    }
}
