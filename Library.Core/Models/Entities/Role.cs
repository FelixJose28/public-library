using System;
using System.Collections.Generic;

namespace Library.Core.Models.Entities
{
    public class Role : BaseEntity
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
