using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SunglassesApp.Models;
using System.Reflection.Emit;

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
        public DbSet<SupportTicket> SupportTickets { get; set; }

        public DbSet<SupportTicketMessage> SupportTicketMessages { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SupportTicketMessage>()
                .HasOne(m => m.Ticket)
                .WithMany(t => t.Messages)
                .HasForeignKey(m => m.TicketId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.Entity<SupportTicketMessage>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict); 

            var userRoleId = "38ba0b14-cd93-4e0f-a74f-b1080e7e4c48";
            var adminRoleId = "218f1a02-f071-4468-b646-48a24e11e1d8";
            

            var userId = "e0f3556e-bb32-4115-9314-a112ff7bb605";
            var adminId = "7700ff9b-8646-4813-b20d-ad27d6894c7e";
            

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
                UserName = "user_ITS",
                NormalizedUserName = "USER_ITS",
                Email = "test@gmail.com",
                NormalizedEmail = "TEST@GMAIL.COM",
                EmailConfirmed = true,
                Id = userId
            };

            user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, "123456");

            var adminUser = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "Admin_ITS",
                NormalizedUserName = "ADMIN_ITS",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                Id = adminId
            };

            adminUser.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(adminUser, "123456");


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
