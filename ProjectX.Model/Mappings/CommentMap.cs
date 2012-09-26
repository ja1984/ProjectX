using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectX.Model.Entities;

namespace ProjectX.Model.Mappings
{
    class CommentMap : EntityMap<Comment>
    {

        public CommentMap()
        {
            Map(x => x.Message);
            Map(x => x.Sent);

            References(x => x.Project);
            References(x => x.User);

        }

    }
}
