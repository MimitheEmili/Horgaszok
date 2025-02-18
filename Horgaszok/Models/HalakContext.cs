using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Horgaszok.Models;

public partial class HalakContext : DbContext
{
    public HalakContext()
    {
    }

    public HalakContext(DbContextOptions<HalakContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fogasok> Fogasoks { get; set; }

    public virtual DbSet<Halak> Halaks { get; set; }

    public virtual DbSet<Horgaszok> Horgaszoks { get; set; }

    public virtual DbSet<Tavak> Tavaks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("SERVER=localhost;PORT=3306;DATABASE=halak;USER=root;PASSWORD=;SSL MODE=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fogasok>(entity =>
        {
            entity.HasKey(e => e.FogasokId).HasName("PRIMARY");

            entity.ToTable("fogasok");

            entity.HasIndex(e => e.HalId, "hal_id");

            entity.HasIndex(e => e.HorgaszokId, "horgaszok_id");

            entity.Property(e => e.FogasokId)
                .HasColumnType("int(11)")
                .HasColumnName("fogasok_id");
            entity.Property(e => e.Datum)
                .HasColumnType("date")
                .HasColumnName("datum");
            entity.Property(e => e.HalId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("hal_id");
            entity.Property(e => e.HorgaszokId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("horgaszok_id");

            entity.HasOne(d => d.Hal).WithMany(p => p.Fogasoks)
                .HasForeignKey(d => d.HalId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fogasok_ibfk_1");

            entity.HasOne(d => d.Horgaszok).WithMany(p => p.Fogasoks)
                .HasForeignKey(d => d.HorgaszokId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fogasok_ibfk_2");
        });

        modelBuilder.Entity<Halak>(entity =>
        {
            entity.HasKey(e => e.HalakId).HasName("PRIMARY");

            entity.ToTable("halak");

            entity.HasIndex(e => e.ToId, "to_id");

            entity.Property(e => e.HalakId)
                .HasColumnType("int(11)")
                .HasColumnName("halak_id");
            entity.Property(e => e.HalFaj)
                .HasMaxLength(100)
                .HasColumnName("hal_faj");
            entity.Property(e => e.HalNev)
                .HasMaxLength(100)
                .HasColumnName("hal_nev");
            entity.Property(e => e.Kep)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("blob")
                .HasColumnName("kep");
            entity.Property(e => e.MeretCm)
                .HasPrecision(5)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("meret_cm");
            entity.Property(e => e.ToId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("to_id");

            entity.HasOne(d => d.To).WithMany(p => p.Halaks)
                .HasForeignKey(d => d.ToId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("halak_ibfk_1");
        });

        modelBuilder.Entity<Horgaszok>(entity =>
        {
            entity.HasKey(e => e.HorgaszokId).HasName("PRIMARY");

            entity.ToTable("horgaszok");

            entity.Property(e => e.HorgaszokId)
                .HasColumnType("int(11)")
                .HasColumnName("horgaszok_id");
            entity.Property(e => e.Eletkor)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("eletkor");
            entity.Property(e => e.HorgaszokNev)
                .HasMaxLength(100)
                .HasColumnName("horgaszok_nev");
        });

        modelBuilder.Entity<Tavak>(entity =>
        {
            entity.HasKey(e => e.TavakId).HasName("PRIMARY");

            entity.ToTable("tavak");

            entity.Property(e => e.TavakId)
                .HasColumnType("int(11)")
                .HasColumnName("tavak_id");
            entity.Property(e => e.Helyszin)
                .HasMaxLength(100)
                .HasColumnName("helyszin");
            entity.Property(e => e.ToNev)
                .HasMaxLength(100)
                .HasColumnName("to_nev");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
