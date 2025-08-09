using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SunglassesApp.Models;

namespace SunglassesApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            var userRoleId = "38ba0b14-cd93-4e0f-a74f-b1080e7e4c48";
            var adminRoleId = "218f1a02-f071-4468-b646-48a24e11e1d8";
            

            var userId = "80c32529-9d23-4d53-a0b3-89c710f5fd96";
            var adminId = "e1976e68-c98a-46f6-9f1e-c0a87ef94609";
            

            var roles = new List<IdentityRole>
             {
                 new IdentityRole
                 {
                     Name = "Admin",
                     NormalizedName = "ADMIN",
                     Id = adminRoleId,
                     ConcurrencyStamp = adminRoleId
                 },

                 new IdentityRole
                 {
                     Name = "User",
                     NormalizedName = "USER",
                     Id = userRoleId,
                     ConcurrencyStamp = userRoleId
                 },
         
             };

            builder.Entity<IdentityRole>().HasData(roles);

            var user = new ApplicationUser
            {
                FirstName = "FirstName",
                LastName = "LastName",
                UserName = "user35",
                NormalizedUserName = "USER35",
                Email = "test@gmail.com",
                NormalizedEmail = "TEST@GMAIL.COM",
                EmailConfirmed = true,
                Id = userId
            };

            user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, "Miks_03112002");

            var adminUser = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "Admin02",
                NormalizedUserName = "ADMIN02",
                Email = "admin02@gmail.com",
                NormalizedEmail = "ADMIN02@GMAIL.COM",
                EmailConfirmed = true,
                Id = adminId
            };

            adminUser.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(adminUser, "Miks_03112002");


            builder.Entity<ApplicationUser>().HasData(user);
            builder.Entity<ApplicationUser>().HasData(adminUser);

           

            var userRoles = new List<IdentityUserRole<string>>
             {
                 new IdentityUserRole<string>
                 {
                     RoleId = userRoleId,
                     UserId = userId
                 },
                 new IdentityUserRole<string>
                 {
                     RoleId = adminRoleId,
                     UserId = adminId
                 },
     
             };

            builder.Entity<IdentityUserRole<string>>().HasKey(ur => new { ur.UserId, ur.RoleId });
            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);




        }
    }

}
