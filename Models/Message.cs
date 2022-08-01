using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public string? Message1 { get; set; }
        public DateTime? TimestampCreated { get; set; }
        public DateTime? TimestampModified { get; set; }
        public int? Receiver { get; set; }
        public int? Sender { get; set; }

    }
}
