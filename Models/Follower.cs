using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class Follower
    {
        public int Id { get; set; }
        public int? Status { get; set; }
        public DateTime? TimestampCreated { get; set; }
        public DateTime? TimestampModified { get; set; }
        public int? Followedby { get; set; }
        public int? Follower1 { get; set; }

        public virtual User? FollowedbyNavigation { get; set; }
        public virtual User? Follower1Navigation { get; set; }
    }
}
