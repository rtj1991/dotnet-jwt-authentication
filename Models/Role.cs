using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Models
{
    public partial class Role
    {
        public Role()
        {
            TimestampCreated = DateTime.UtcNow;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        public string? Description { get; set; }
        public bool? Enabled { get; set; }
        public string Role1 { get; set; } = null!;
        public DateTime? TimestampCreated { get; set; }
        public DateTime? TimestampModified { get; set; }

        public virtual ICollection<User_Role>?user_Roles { get; set; }

    }
}
