using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectX.Model.Entities;


namespace ProjectX.Model.Mappings
{
    class FollowMap : EntityMap<Follow>
    {
        public FollowMap()
        {
            References(x => x.User).Cascade.All();
        }

    }
}
