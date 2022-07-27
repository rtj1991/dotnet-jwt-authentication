using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class Gallery
    {
        public int Id { get; set; }
        public bool? Enabled { get; set; }
        public string? Image { get; set; }
        public DateTime? TimestampCreated { get; set; }
        public DateTime? TimestampModified { get; set; }
        public int? CreatedUser { get; set; }

        public virtual User? CreatedUserNavigation { get; set; }
    }
}
