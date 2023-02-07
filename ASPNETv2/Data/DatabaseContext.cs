using ASPNETv2.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETv2.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Note> Notes { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to One: Users - Profiles
            // One to Many: Profiles - Notes
            // Many to Many: Profiles - Groups

            // Profiles - Notes:
            modelBuilder.Entity<Profile>()
                .HasMany(profile => profile.Notes)
                .WithOne(note => note.Profile);

            // Profiles - Groups
            modelBuilder.Entity<ProfileGroupRelation>()
                .HasKey(mr => new { mr.ProfileId, mr.GroupId });

            modelBuilder.Entity<ProfileGroupRelation>()
                .HasOne<Profile>(mr => mr.Profile)
                .WithMany(profile => profile.ProfileGroupRelations)
                .HasForeignKey(mr => mr.ProfileId);

            modelBuilder.Entity<ProfileGroupRelation>()
                .HasOne<Group>(mr => mr.Group)
                .WithMany(group => group.ProfileGroupRelations)
                .HasForeignKey(mr => mr.GroupId);

            // Users - Profiles

            modelBuilder.Entity<User>()
                .HasOne(user => user.Profile)
                .WithOne(profile => profile.User)
                .HasForeignKey<Profile>(profile => profile.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
