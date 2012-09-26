using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectX.Model.Entities;

namespace ProjectX.Model.Mappings
{
    class PrivateMessageMap : EntityMap<PrivateMessage>
    {

        public PrivateMessageMap()
        {
            Map(x => x.Header);
            Map(x => x.Message).Length(4001);
            Map(x => x.IsRead);
            Map(x => x.Sent);
            References(x => x.Sender);
            References(x => x.Reciever);

        }

    }
}
