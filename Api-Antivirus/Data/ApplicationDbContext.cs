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
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Institucion> Instituciones { get; set; }
        public DbSet<Tematica> Tematicas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Oportunidad> Oportunidades { get; set; }
        public DbSet<OportunidadInstitucion> OportunidadInstitucion { get; set; }
        public DbSet<UsuarioOportunidad> UsuarioOportunidades { get; set; }
        public DbSet<Bootcamp> Bootcamps { get; set; }
        public DbSet<BootcampTematica> BootcampTematicas { get; set; }
        public DbSet<InstitucionBootcamp> InstitucionBootcamps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar claves compuestas
            modelBuilder.Entity<OportunidadInstitucion>()
                .HasKey(oi => new { oi.IdOportunidad, oi.IdInstitucion });

            modelBuilder.Entity<UsuarioOportunidad>()
                .HasKey(uo => new { uo.IdUsuario, uo.IdOportunidad });

            modelBuilder.Entity<BootcampTematica>()
                .HasKey(bt => new { bt.IdBootcamp, bt.IdTematica });

            modelBuilder.Entity<InstitucionBootcamp>()
                .HasKey(ib => new { ib.IdInstitucion, ib.IdBootcamp });
        }
    }
}