using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace COMP4900Project.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<Friend> Friend1 { get; set; }
        public virtual ICollection<Friend> Friend2 { get; set; }

        public virtual ICollection<UserContent> UserContents { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>()
                    .HasRequired(m => m.User1)
                    .WithMany(t => t.Friend1)
                    .HasForeignKey(m => m.User1Id)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Friend>()
                        .HasRequired(m => m.User2)
                        .WithMany(t => t.Friend2)
                        .HasForeignKey(m => m.User2Id)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public System.Data.Entity.DbSet<COMP4900Project.Models.Friend> Friends { get; set; }
        public System.Data.Entity.DbSet<COMP4900Project.Models.UserContent> UserContents { get; set; }
        public System.Data.Entity.DbSet<COMP4900Project.Models.Content> Contents { get; set; }
        public System.Data.Entity.DbSet<COMP4900Project.Models.UserGroup> UserGroups { get; set; }
        public System.Data.Entity.DbSet<COMP4900Project.Models.Group> Groups { get; set; }
        public System.Data.Entity.DbSet<COMP4900Project.Models.ContentGroup> ContentGroups { get; set; }
    }
}