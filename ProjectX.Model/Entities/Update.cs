﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectX.Model.Entities
{
    public class Update : Entity
    {
        public virtual string Header { get; set; }
        public virtual string Message { get; set; }
        public virtual DateTime Added { get; set; }
        public virtual UpdateType Type { get; set; }
        public virtual User Author { get; set; }
        public virtual Project Project { get; set; }
    }


    public enum UpdateType
    {
        useradded,
        projectupdate,
        newopening,
        addedbuild,
        userdeleted

    }
}
