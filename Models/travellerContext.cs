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

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Book_Category> Book_Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Category>()
            .HasOne(b => b.Book)
            .WithMany(ba => ba.Book_Categories)
            .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_Category>()
            .HasOne(b => b.Category)
            .WithMany(ba => ba.Book_Categories)
            .HasForeignKey(bi => bi.CategoryId);

            modelBuilder.Entity<Follower>()
            .HasOne(b => b.followed_by)
            .WithMany(ba => ba.followed_by)
            .HasForeignKey(bi => bi.Followedby);

            modelBuilder.Entity<Follower>()
            .HasOne(b => b.followers)
            .WithMany(ba => ba.Followers)
            .HasForeignKey(bi => bi.follower);

            modelBuilder.Entity<Message>()
            .HasOne(b => b.Receivers)
            .WithMany(ba => ba.Receivers)
            .HasForeignKey(bi => bi.Receiver);

            modelBuilder.Entity<Message>()
            .HasOne(b => b.Senders)
            .WithMany(ba => ba.Senders)
            .HasForeignKey(bi => bi.Sender);

            modelBuilder.Entity<Gallery>()
            .HasOne(b => b.GCreateduser)
            .WithMany(ba => ba.GCreateduser)
            .HasForeignKey(bi => bi.CreatedUser);
        }
    }
}