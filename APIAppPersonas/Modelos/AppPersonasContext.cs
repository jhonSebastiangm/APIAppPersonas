using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APIAppPersonas.Modelos
{
    public partial class AppPersonasContext : DbContext
    {
        public AppPersonasContext()
        {
        }

        public AppPersonasContext(DbContextOptions<AppPersonasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PersonaJuridica> PersonaJuridicas { get; set; }
        public virtual DbSet<PersonaNatural> PersonaNaturals { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<PersonaJuridica>(entity =>
            {
                entity.HasKey(e => e.Nit);

                entity.ToTable("PersonaJuridica");

                entity.Property(e => e.Nit).ValueGeneratedNever();

                entity.Property(e => e.Letra1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Letra2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Municipio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NroAndComplements)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Via)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdentificacionNavigation)
                    .WithMany(p => p.PersonaJuridicas)
                    .HasForeignKey(d => d.Identificacion)
                    .HasConstraintName("FK_PersonaJuridica_PersonaNatural");

                entity.HasOne(d => d.TipoPersona)
                    .WithMany(p => p.PersonaJuridicas)
                    .HasForeignKey(d => d.TipoPersonaId)
                    .HasConstraintName("FK_PersonaJuridica_TipoDocumento");
            });

            modelBuilder.Entity<PersonaNatural>(entity =>
            {
                entity.HasKey(e => e.Identificacion);

                entity.ToTable("PersonaNatural");

                entity.Property(e => e.Identificacion).ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Letra1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Letra2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Municipio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NroAndComplements)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Via)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoPersona)
                    .WithMany(p => p.PersonaNaturals)
                    .HasForeignKey(d => d.TipoPersonaId)
                    .HasConstraintName("FK_PersonaNatural_TipoDocumento");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento);

                entity.ToTable("TipoDocumento");

                entity.Property(e => e.NombreDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
