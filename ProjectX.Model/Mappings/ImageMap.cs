using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectX.Model.Entities;

namespace ProjectX.Model.Mappings
{
    class ImageMap : EntityMap<Image>
    {
        public ImageMap()
        {
            Map(x => x.Added);
            Map(x => x.Name);
            References(x => x.Project);
        }

    }
}
