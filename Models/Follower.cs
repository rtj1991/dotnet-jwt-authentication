using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProductAPI.Models
{
    public partial class Follower
    {
        public Follower()
        {
            TimestampCreated = DateTime.UtcNow;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? Status { get; set; }
        public DateTime? TimestampCreated { get; set; }
        public DateTime? TimestampModified { get; set; }

        [ForeignKey("Followedby")]
        public int? Followedby { get; set; }
        [JsonIgnore]
        public virtual User? followed_by { get; set; }

        [ForeignKey("follower")]
        public int follower { get; set; }
        
        [JsonIgnore]
        public virtual User? followers { get; set; }

    }
}
