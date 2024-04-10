using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatosZone
{
    public partial class AplicacionContext : DbContext
    {
        public AplicacionContext()
            : base("name=AplicacionContext")
        {
        }

        public virtual DbSet<Aplicacion> Aplicacion { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aplicacion>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Aplicacion>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Aplicacion>()
                .Property(e => e.desarrolladora)
                .IsUnicode(false);

            modelBuilder.Entity<Aplicacion>()
                .Property(e => e.precio)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Aplicacion)
                .WithRequired(e => e.Categoria)
                .WillCascadeOnDelete(false);
        }
    }
}
