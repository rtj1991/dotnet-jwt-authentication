using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProductAPI.Models
{
    public partial class Review
    {
        public Review()
        {
            TimestampCreated = DateTime.UtcNow;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Comment { get; set; }
        public string? Rating { get; set; }
        public DateTime? TimestampCreated { get; set; }
        public DateTime? TimestampModified { get; set; }
        [ForeignKey("Reviewer")]
        public int? Reviewer { get; set; }
        [JsonIgnore]
        public MyTrip Reviewers { get; set; }

        [ForeignKey("CreatedUser")]
        public int? CreatedUser { get; set; }
        [JsonIgnore]
        public virtual User FCreatedUsers { get; set; }


    }
}
