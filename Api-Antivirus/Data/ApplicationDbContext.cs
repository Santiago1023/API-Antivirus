using Microsoft.EntityFrameworkCore;
using Api_Antivirus.Models;
using System;
using System.Collections.Generic;

namespace Api_Antivirus.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Agrega DbSet para cada modelo
        public DbSet<Category> Categories { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<OpportunityInstitution> OpportunityInstitutions { get; set; }
        public DbSet<User_Opportunity> UserOpportunities { get; set; }
        public DbSet<Bootcamp> Bootcamps { get; set; }
        public DbSet<BootcampTopic> BootcampTopics { get; set; }
            public DbSet<InstitutionBootcamp> InstitutionBootcamps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar claves compuestas
            modelBuilder.Entity<OpportunityInstitution>()
                .HasKey(oi => new { oi.OpportunityId, oi.InstitutionId });

            modelBuilder.Entity<User_Opportunity>()
                .HasKey(uo => new { uo.UserId, uo.OpportunityId });

            modelBuilder.Entity<BootcampTopic>()
                .HasKey(bt => new { bt.BootcampId, bt.TopicId });

            modelBuilder.Entity<InstitutionBootcamp>()
                .HasKey(ib => new { ib.InstitutionId, ib.BootcampId });

            //se define relacion User_Opportunity
            //User
            modelBuilder.Entity<User_Opportunity>()
                .HasOne<User> (uo => uo.User)
                .WithMany (u => u.User_Opportunity)
                .HasForeignKey (uo => uo.UserId);
            //Opportunity
            modelBuilder.Entity<User_Opportunity>()
                .HasOne<Opportunity> (ou => ou.Opportunity)
                .WithMany (o => o.User_Opportunity)
                .HasForeignKey (ou => ou.OpportunityId);
        }
    }
}
