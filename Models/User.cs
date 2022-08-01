using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class User
    {

        public int UserId { get; set; }
        public string Dob { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Gender { get; set; }
        public string Location { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Password { get; set; }
        public string? ProfilePic { get; set; }
        public DateTime? TimestampCreated { get; set; }
        public DateTime? TimestampModified { get; set; }
        public string Role { get; set; }=null!;

    }
}
