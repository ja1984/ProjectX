using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectX.Model.Entities;

namespace ProjectX.Model.Mappings
{
    class LanguageMap : EntityMap<Language>
    {
        public LanguageMap()
        {
            Map(x => x.Name);
        }

    }
}
