using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectX.Model.Entities
{
    public class Image : Entity
    {

        public virtual string Name { get; set; }
        public virtual Project Project { get; set; }
        public virtual DateTime Added { get; set; }

    }
}