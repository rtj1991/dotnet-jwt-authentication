using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public string? Rating { get; set; }
        public DateTime? TimestampCreated { get; set; }
        public DateTime? TimestampModified { get; set; }
        public int? Reviewer { get; set; }
        public int? CreatedUser { get; set; }

    
    }
}
