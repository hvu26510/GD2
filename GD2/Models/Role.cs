﻿namespace GD2.Models
{
    public class Role
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
