using Contacts.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data
{
    public class ContactsDbContext : IdentityDbContext
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
            /* builder
                .Entity<Contact>()
                .HasData(new Contact()
                {
                    Id = 1,
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    PhoneNumber = "+359881223344",
                    Address = "Gotham City",
                    Email = "imbatman@batman.com",
                    Website = "www.batman.com"
                });
            */
        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; } 

        public DbSet<ApplicationUserContact> ApplicationUsersContacts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
              .Entity<Contact>()
              .HasData(new Contact()
              {
                  Id = 1,
                  FirstName = "Bruce",
                  LastName = "Wayne",
                  PhoneNumber = "+359881223344",
                  Address = "Gotham City",
                  Email = "imbatman@batman.com",
                  Website = "www.batman.com"
              });

            builder
                .Entity<ApplicationUserContact>()
                .HasKey(a => new { a.ApplicationUserId, a.ContactId });

            builder
                .Entity<ApplicationUserContact>()
                .HasOne(a => a.Contact)
                .WithMany()
                .HasForeignKey(a => a.ContactId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<ApplicationUserContact>()
                .HasOne(a => a.ApplicationUser)
                .WithMany()
                .HasForeignKey(a => a.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}