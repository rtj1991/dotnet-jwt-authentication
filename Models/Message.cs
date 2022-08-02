using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProductAPI.Models
{
    public partial class Message
    {
        public Message(){
            TimestampCreated=DateTime.UtcNow;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Messages { get; set; }
        public DateTime? TimestampCreated { get; set; }
        public DateTime? TimestampModified { get; set; }
        [ForeignKey("Receiver")]
        public int? Receiver { get; set; }
        [JsonIgnore]
        public virtual User Receivers { get; set; }

        [ForeignKey("Sender")]
        public int? Sender { get; set; }
        [JsonIgnore]
        public virtual User Senders { get; set; }

    }
}
