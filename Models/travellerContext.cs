using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Models
{
    public partial class travellerContext : DbContext
    {
        public travellerContext()
        {
        }

        public travellerContext(DbContextOptions<travellerContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Follower> Followers { get; set; } = null!;
        public virtual DbSet<Gallery> Galleries { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<MyTrip> MyTrips { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Follower>(entity =>
            {
                entity.ToTable("follower");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Followedby).HasColumnName("followedby");

                entity.Property(e => e.Follower1).HasColumnName("follower");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TimestampCreated)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("timestamp_created");

                entity.Property(e => e.TimestampModified)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("timestamp_modified");

                entity.HasOne(d => d.FollowedbyNavigation)
                    .WithMany(p => p.FollowerFollowedbyNavigations)
                    .HasForeignKey(d => d.Followedby)
                    .HasConstraintName("fk_followedby");

                entity.HasOne(d => d.Follower1Navigation)
                    .WithMany(p => p.FollowerFollower1Navigations)
                    .HasForeignKey(d => d.Follower1)
                    .HasConstraintName("fk_follower");
            });

            modelBuilder.Entity<Gallery>(entity =>
            {
                entity.ToTable("gallery");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedUser).HasColumnName("created_user");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image");

                entity.Property(e => e.TimestampCreated)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("timestamp_created");

                entity.Property(e => e.TimestampModified)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("timestamp_modified");

                entity.HasOne(d => d.CreatedUserNavigation)
                    .WithMany(p => p.Galleries)
                    .HasForeignKey(d => d.CreatedUser)
                    .HasConstraintName("fk_created_user");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("message");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Message1)
                    .HasMaxLength(255)
                    .HasColumnName("message");

                entity.Property(e => e.Receiver).HasColumnName("receiver");

                entity.Property(e => e.Sender).HasColumnName("sender");

                entity.Property(e => e.TimestampCreated)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("timestamp_created");

                entity.Property(e => e.TimestampModified)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("timestamp_modified");

                entity.HasOne(d => d.ReceiverNavigation)
                    .WithMany(p => p.MessageReceiverNavigations)
                    .HasForeignKey(d => d.Receiver)
                    .HasConstraintName("fk_receiver");

                entity.HasOne(d => d.SenderNavigation)
                    .WithMany(p => p.MessageSenderNavigations)
                    .HasForeignKey(d => d.Sender)
                    .HasConstraintName("fk_sender");
            });

            modelBuilder.Entity<MyTrip>(entity =>
            {
                entity.ToTable("my_trips");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedUser).HasColumnName("created_user");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.EndDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("end_date");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("location");

                entity.Property(e => e.StartDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("start_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TimestampCreated)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("timestamp_created");

                entity.Property(e => e.TimestampModified)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("timestamp_modified");

                entity.HasOne(d => d.CreatedUserNavigation)
                    .WithMany(p => p.MyTrips)
                    .HasForeignKey(d => d.CreatedUser)
                    .HasConstraintName("fk_created_user");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("review");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .HasColumnName("comment");

                entity.Property(e => e.CreatedUser).HasColumnName("created_user");

                entity.Property(e => e.Rating)
                    .HasMaxLength(255)
                    .HasColumnName("rating");

                entity.Property(e => e.Reviewer).HasColumnName("reviewer");

                entity.Property(e => e.TimestampCreated)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("timestamp_created");

                entity.Property(e => e.TimestampModified)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("timestamp_modified");

                entity.HasOne(d => d.CreatedUserNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CreatedUser)
                    .HasConstraintName("fk_created_user");

                entity.HasOne(d => d.ReviewerNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Reviewer)
                    .HasConstraintName("fk_reviewer");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.HasIndex(e => e.Role1, "uk_role")
                    .IsUnique();

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Role1)
                    .HasMaxLength(255)
                    .HasColumnName("role");

                entity.Property(e => e.TimestampCreated)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("timestamp_created");

                entity.Property(e => e.TimestampModified)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("timestamp_modified");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Email, "uk_email")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Dob)
                    .HasMaxLength(255)
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("location");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.ProfilePic)
                    .HasMaxLength(255)
                    .HasColumnName("profile_pic");

                entity.Property(e => e.TimestampCreated)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("timestamp_created");

                entity.Property(e => e.TimestampModified)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("timestamp_modified");

                    entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .HasColumnName("role");

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UsersRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_role_id"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_user_id"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("users_roles_pkey");

                            j.ToTable("users_roles");

                            j.IndexerProperty<int>("UserId").HasColumnName("user_id");

                            j.IndexerProperty<int>("RoleId").HasColumnName("role_id");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
