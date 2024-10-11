﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Resources
{
    public class UserResource
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? ID { get; set; }
        public string? Gender { get; set; }
        public DateTime CreateDate { get; set; }

        public Guid? RoleId { get; set; }
        public string? Role { get; set; }
    }
}
