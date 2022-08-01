using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Models
{
    public class Places
    {
        [Key]
        public int Id { get; set; }

        public String? Name { get; set; }
        public String? Description { get; set; }
        public String? Coordinates { get; set; }

        [ForeignKey("MyTrip")]
        public int TripId { get; set; }
        public virtual MyTrip? MyTrip { get; set; }
    }
}