namespace ProductAPI.Container.Entity;
public class TripEntity{
    public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Location { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Status { get; set; }
        public DateTime? TimestampCreated { get; set; }
        public DateTime? TimestampModified { get; set; }
        public int? CreatedUser { get; set; }

}