using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string? Description { get; set; }
        public bool? Enabled { get; set; }
        public string Role1 { get; set; } = null!;
        public DateTime? TimestampCreated { get; set; }
        public DateTime? TimestampModified { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
