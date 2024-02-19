﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data.Entities;

namespace SeminarHub.Data
{
    public class SeminarHubDbContext : IdentityDbContext
    {
        public SeminarHubDbContext(DbContextOptions<SeminarHubDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Seminar> Seminars { get; set; }

        public DbSet<SeminarParticipant> SeminarsParticipants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
               .Entity<Category>()
               .HasData(new Category()
               {
                   Id = 1,
                   Name = "Technology & Innovation"
               },
               new Category()
               {
                   Id = 2,
                   Name = "Business & Entrepreneurship"
               },
               new Category()
               {
                   Id = 3,
                   Name = "Science & Research"
               },
               new Category()
               {
                   Id = 4,
                   Name = "Arts & Culture"
               });

            builder.Entity<SeminarParticipant>()
                .HasKey(s => new { s.SeminarId, s.ParticipantId });

            builder.Entity<SeminarParticipant>()
                .HasOne(c => c.Seminar)
                .WithMany()
                .HasForeignKey(c => c.SeminarId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SeminarParticipant>()
                .HasOne(c => c.Participant)
                .WithMany()
                .HasForeignKey(c => c.ParticipantId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}