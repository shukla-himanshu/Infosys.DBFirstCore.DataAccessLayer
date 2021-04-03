﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Infosys.DBFirstCore.DataAccessLayer.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public byte RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
