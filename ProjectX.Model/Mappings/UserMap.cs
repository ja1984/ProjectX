using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectX.Model.Entities;

namespace ProjectX.Model.Mappings
{
    class UserMap : EntityMap<User>
    {
        public UserMap()
        {
            Map(x => x.Created);
            Map(x => x.Description);
            Map(x => x.DisplayEmail);
            Map(x => x.Email);
            Map(x => x.FirstName);
            Map(x => x.GitHub);
            Map(x => x.GravatarEmail);
            Map(x => x.LastName);
            Map(x => x.Password);
            Map(x => x.Role);
            Map(x => x.Salt);
            Map(x => x.UserName);
            Map(x => x.DisplayName);
        }
    }
}
