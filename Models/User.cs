using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Models
{
    public partial class User
    {
        public User()
        {
            TimestampCreated = DateTime.UtcNow;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public string Role { get; set; } = null!;

        public virtual ICollection<User_Role>? user_Roles { get; set; }
        public virtual ICollection<Follower>? Followers { get; set; }
        public virtual ICollection<Follower>? followed_by { get; set; }
        public virtual ICollection<Review>? FCreatedUsers { get; set; }
        public virtual ICollection<MyTrip> MCreatedUsers { get; set; }
        public virtual ICollection<Message> Receivers { get; set; }
        public virtual ICollection<Message> Senders { get; set; }
        public virtual ICollection<Gallery> GCreateduser { get; set; }

    }
}
