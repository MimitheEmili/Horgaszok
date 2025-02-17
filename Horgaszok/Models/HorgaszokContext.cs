using Microsoft.EntityFrameworkCore;
using Horgaszok.Class;

namespace Horgaszok.Models
{
    public partial class HorgaszokContext : DbContext
    {
        public HorgaszokContext()
        {
        }

        public HorgaszokContext(DbContextOptions<HorgaszokContext> options)
            : base(options)
        {
        }

        // Add DbSet for Fogasok
        public virtual DbSet<Fogasok> Fogasok { get; set; }

        public virtual DbSet<Halak> Halak { get; set; }

        public virtual DbSet<Horgaszok.Class.Horgaszok> Horgaszok { get; set; }

        public virtual DbSet<Tavak> Tavak { get; set; }



        // Add other DbSets as necessary

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("SERVER=localhost;PORT=3306;DATABASE=halak;USER=root;PASSWORD=;SSL MODE=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fogasok>(entity =>
            {
                entity.HasKey(e => e.Fogasok_Id).HasName("PRIMARY");

                entity.ToTable("fogasok");

                entity.Property(e => e.Fogasok_Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("fogasok_id");

                entity.Property(e => e.Hal_Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("hal_id");

                entity.Property(e => e.Horgaszok_Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("horgaszok_id");

                entity.Property(e => e.Datum)
                    .HasColumnType("datetime")
                    .HasColumnName("datum");

                // Add relationships here if needed, for example:
                // entity.HasOne(d => d.Hal).WithMany(p => p.Fogasok).HasForeignKey(d => d.Hal_Id);
                // entity.HasOne(d => d.Horgaszok).WithMany(p => p.Fogasok).HasForeignKey(d => d.Horgaszok_Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
