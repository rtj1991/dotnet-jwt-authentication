using Microsoft.EntityFrameworkCore;
namespace ProductAPI.Models
{
    public class travellerContext : DbContext
    {

        public travellerContext(DbContextOptions<travellerContext> options) : base(options)
        {

        }
        public virtual DbSet<Follower> Followers { get; set; } = null!;
        public virtual DbSet<Gallery> Galleries { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<MyTrip> MyTrips { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Places> Places { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
        }
    }
}