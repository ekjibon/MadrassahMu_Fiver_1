using Subscription.Business.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace Subscription.Data.EntityFramework.Identity
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, long, User_Login, User_Role, User_Claim>
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public static ApplicationDbContext Create()
        {
            //ApplicationDbContext dbContext = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>();
            //if(dbContext == null)
            //    dbContext = new ApplicationDbContext();
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Idt");


            modelBuilder.Entity<User_Login>().Map(c =>
            {
                c.ToTable("User_Login")
                 .Property(p => p.UserId).HasColumnName("IdUser");

                c.Properties(p => new
                {
                    p.LoginProvider,
                    p.ProviderKey,
                });

            }).HasKey(p => new { p.LoginProvider, p.ProviderKey, p.UserId });

            modelBuilder.Entity<Role>().Map(c =>
            {
                c.ToTable("Role")
                 .Property(p => p.Id).HasColumnName("IdRole");
                c.Properties(p => new
                {
                    p.Name
                });
            }).HasKey(p => p.Id);
            modelBuilder.Entity<Role>().HasMany(c => c.Users).WithRequired().HasForeignKey(c => c.RoleId);


            modelBuilder.Entity<User>().Map(c =>
            {
                c.ToTable("User")
                 .Property(p => p.Id).HasColumnName("IdUser");
                c.Properties(p => new
                {
                    p.AccessFailedCount,
                    p.Email,
                    p.EmailConfirmed,
                    p.PasswordHash,
                    p.PhoneNumber,
                    p.PhoneNumberConfirmed,
                    p.TwoFactorEnabled,
                    p.SecurityStamp,
                    p.LockoutEnabled,
                    p.LockoutEndDateUtc,
                    p.UserName,
                    p.NeedPasswordChange,
                    p.Firstname,
                    p.Lastname,
                    p.IdPerson,
                });

            }).HasKey(c => c.Id);
            modelBuilder.Entity<User>().HasMany(c => c.Logins).WithOptional().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<User>().HasMany(c => c.Claims).WithOptional().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<User>().HasMany(c => c.Roles).WithRequired().HasForeignKey(c => c.UserId);

            modelBuilder.Entity<User_Role>().Map(c =>
            {
                c.ToTable("User_Role");
                c.Property(p => p.UserId).HasColumnName("IdUser");
                c.Property(p => p.RoleId).HasColumnName("IdRole");
            })
             .HasKey(c => new { c.UserId, c.RoleId });

            modelBuilder.Entity<User_Claim>().Map(c =>
            {
                c.ToTable("User_Claim");
                c.Property(p => p.Id).HasColumnName("IdUser_Claim");
                c.Property(p => p.UserId).HasColumnName("IdUser");
                c.Properties(p => new
                {
                    p.ClaimValue,
                    p.ClaimType
                });
            }).HasKey(c => new { c.Id });
        }
    }
}
