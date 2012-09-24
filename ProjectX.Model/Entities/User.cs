using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProjectX.Model.Entities
{
    public class User : Entity
    {

        public User()
        {
        }

        public virtual string UserName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string GravatarEmail { get; set; }
        public virtual string Password { get; set; }
        public virtual string Salt { get; set; }
        public virtual string GitHub { get; set; }
        public virtual bool DisplayEmail { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual int Role { get; set; }
        public virtual string Description { get; set; }
        public virtual string DisplayName { get; set; }
    }



}