﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Queries
{
    public class LoginQuery
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? ID { get; set; }
        public string? Gender { get; set; }
        public DateTime CreateDate { get; set; }

        public RoleLoginQuery Role { get; set; }

    }

    public class RoleLoginQuery
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleType { get; set; }
    }
}
