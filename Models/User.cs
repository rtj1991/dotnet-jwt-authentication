using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class User
    {
        public User()
        {
            FollowerFollowedbyNavigations = new HashSet<Follower>();
            FollowerFollower1Navigations = new HashSet<Follower>();
            Galleries = new HashSet<Gallery>();
            MessageReceiverNavigations = new HashSet<Message>();
            MessageSenderNavigations = new HashSet<Message>();
            MyTrips = new HashSet<MyTrip>();
            Reviews = new HashSet<Review>();
            Roles = new HashSet<Role>();
        }

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

        public virtual ICollection<Follower> FollowerFollowedbyNavigations { get; set; }
        public virtual ICollection<Follower> FollowerFollower1Navigations { get; set; }
        public virtual ICollection<Gallery> Galleries { get; set; }
        public virtual ICollection<Message> MessageReceiverNavigations { get; set; }
        public virtual ICollection<Message> MessageSenderNavigations { get; set; }
        public virtual ICollection<MyTrip> MyTrips { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
