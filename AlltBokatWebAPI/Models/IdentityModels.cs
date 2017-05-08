using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.Collections.Generic;

namespace AlltBokatWebAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<BookingModels> Bookings { get; set; }
        public virtual ICollection<UserRatingModels> UserRatings { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("FirstName", this.FirstName.ToString()));
            userIdentity.AddClaim(new Claim("LastName", this.LastName.ToString()));

            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<BookingModels> Bookings { get; set; }
        public DbSet<BookingTimeSlotModels> BookingTimeSlots { get; set; }
        public DbSet<UserRatingModels> UserRatings { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            //modelBuilder.Entity<BookingModels>()
            //    .HasRequired(s => s.BookingTimeSlotModels)
            //    .(b => b.BookingModels);


            //modelBuilder.Entity<BookingModels>()
            //    .HasRequired(t => t.BookingTimeSlotModels)
            //    .WithOptional()

            modelBuilder.Entity<BookingModels>()
                .HasRequired(a => a.ApplicationUser)
                .WithMany(b => b.Bookings)
                .HasForeignKey(t => t.ApplicationUserId);



            //modelBuilder.Entity<BookingTimeSlotModels>()
            //    .HasOptional(b => b.BookingModels)
            //    .WithRequired(b => b.BookingTimeSlotModels);

            modelBuilder.Entity<UserRatingModels>()
                .HasRequired(a => a.ApplicationUser)
                .WithMany(u => u.UserRatings)
                .HasForeignKey(t => t.ApplicationUserId);
                
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<AlltBokatWebAPI.Models.CategoryModels> CategoryModels { get; set; }

        public System.Data.Entity.DbSet<AlltBokatWebAPI.Models.VisualSettingsModel> VisualSettingsModels { get; set; }

        public System.Data.Entity.DbSet<AlltBokatWebAPI.Models.BusinessHoursModels> BusinessHoursModels { get; set; }
    }
}