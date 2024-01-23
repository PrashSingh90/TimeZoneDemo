using Guest_BO.DataModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Guest_DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<GuestPhoneNumber> GuestPhoneNumbers { get; set; }
        public DbSet<Title> Titles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GuestPhoneNumber>().ToTable("GuestPhoneNumber");
            modelBuilder.Entity<Guest>().ToTable("Guest");
            modelBuilder.Entity<PhoneNumber>().ToTable("PhoneNumber");
            modelBuilder.Entity<Title>().ToTable("Title");
      
        }
    }
}
