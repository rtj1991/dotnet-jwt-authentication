using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Models
{
    public partial class Gallery
    {
        public Gallery(){
            TimestampCreated=DateTime.UtcNow;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool? Enabled { get; set; }
        public string? Image { get; set; }
        public DateTime? TimestampCreated { get; set; }
        public DateTime? TimestampModified { get; set; }
        [ForeignKey("CreatedUser")]
        public int? CreatedUser { get; set; }
        public virtual User GCreateduser { get; set; }

    
    }
}
