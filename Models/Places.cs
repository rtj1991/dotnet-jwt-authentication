using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProductAPI.Models
{
    public class Places
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String? Name { get; set; }
        public String? Description { get; set; }
        public String? Coordinates { get; set; }

        [ForeignKey("TripId")]
        public int? TripId { get; set; }
        
        [JsonIgnore]
        public virtual MyTrip? MyTrips { get; set; }
    }
}