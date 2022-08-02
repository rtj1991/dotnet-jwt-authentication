using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductAPI.Models
{
    public partial class MyTrip
    {
        public MyTrip()
        {
            Place = new HashSet<Places>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Location { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Status { get; set; }
        public DateTime? TimestampCreated { get; set; }
        public DateTime? TimestampModified { get; set; }
        public int? CreatedUser { get; set; }

        public virtual ICollection<Places> Place { get; set; }


    }
}
