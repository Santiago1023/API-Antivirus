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
        public DbSet<category> categories { get; set; }
        public DbSet<institution> institutions { get; set; }
        public DbSet<topic> topics { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<opportunity> opportunities { get; set; }
        public DbSet<opportunity_institution> opportunity_institutions { get; set; }
        public DbSet<user_opportunity> user_opportunities { get; set; }
        public DbSet<bootcamp> bootcamps { get; set; }
        public DbSet<bootcamp_topic> bootcamp_topics { get; set; }
        public DbSet<institution_bootcamp> institution_bootcamps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar claves compuestas
            modelBuilder.Entity<opportunity_institution>()
                .HasKey(oi => new { oi.opportunity_id, oi.institution_id });

            modelBuilder.Entity<user_opportunity>()
                .HasKey(uo => new { uo.user_id, uo.opportunity_id });

            modelBuilder.Entity<bootcamp_topic>()
                .HasKey(bt => new { bt.bootcamp_id, bt.topic_id });

            modelBuilder.Entity<institution_bootcamp>()
                .HasKey(ib => new { ib.institution_id, ib.bootcamp_id });
        }
    }
}