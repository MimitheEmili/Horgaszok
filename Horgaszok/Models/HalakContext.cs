using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Horgaszadatok.Models;

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
            entity.HasKey(e => e.fogasok_id).HasName("PRIMARY");

            entity.ToTable("fogasok");

            entity.HasIndex(e => e.hal_id, "hal_id");

            entity.HasIndex(e => e.horgaszok_id, "horgaszok_id");

            entity.Property(e => e.fogasok_id)
                .HasColumnType("int(11)")
                .HasColumnName("fogasok_id");
            entity.Property(e => e.datum)
                .HasColumnType("date")
                .HasColumnName("datum");
            entity.Property(e => e.hal_id)
                .HasColumnType("int(11)")
                .HasColumnName("hal_id");
            entity.Property(e => e.horgaszok_id)
                .HasColumnType("int(11)")
                .HasColumnName("horgaszok_id");

            entity.HasOne(d => d.Hal).WithMany(p => p.Fogasoks)
                .HasForeignKey(d => d.hal_id)
                .HasConstraintName("fogasok_ibfk_1");

            entity.HasOne(d => d.Horgaszok).WithMany(p => p.Fogasoks)
                .HasForeignKey(d => d.horgaszok_id)
                .HasConstraintName("fogasok_ibfk_2");
        });

        modelBuilder.Entity<Halak>(entity =>
        {
            entity.HasKey(e => e.halak_id).HasName("PRIMARY");

            entity.ToTable("halak");

            entity.HasIndex(e => e.to_id, "to_id");

            entity.Property(e => e.halak_id)
                .HasColumnType("int(11)")
                .HasColumnName("halak_id");
            entity.Property(e => e.hal_faj)
                .HasMaxLength(100)
                .HasColumnName("hal_faj");
            entity.Property(e => e.hal_nev)
                .HasMaxLength(100)
                .HasColumnName("hal_nev");
            entity.Property(e => e.kep)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("blob")
                .HasColumnName("kep");
            entity.Property(e => e.meret_cm)
                .HasPrecision(5)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("meret_cm");
            entity.Property(e => e.to_id)
                .HasColumnType("int(11)")
                .HasColumnName("to_id");

            entity.HasOne(d => d.To).WithMany(p => p.Halaks)
                .HasForeignKey(d => d.to_id)
                .HasConstraintName("halak_ibfk_1");
        });

        modelBuilder.Entity<Horgaszok>(entity =>
        {
            entity.HasKey(e => e.horgaszok_id).HasName("PRIMARY");

            entity.ToTable("horgaszok");

            entity.Property(e => e.horgaszok_id)
                .HasColumnType("int(11)")
                .HasColumnName("horgaszok_id");
            entity.Property(e => e.eletkor)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("eletkor");
            entity.Property(e => e.horgaszok_nev)
                .HasMaxLength(100)
                .HasColumnName("horgaszok_nev");
        });

        modelBuilder.Entity<Tavak>(entity =>
        {
            entity.HasKey(e => e.tavak_id).HasName("PRIMARY");

            entity.ToTable("tavak");

            entity.Property(e => e.tavak_id)
                .HasColumnType("int(11)")
                .HasColumnName("tavak_id");
            entity.Property(e => e.helyszin)
                .HasMaxLength(100)
                .HasColumnName("helyszin");
            entity.Property(e => e.to_nev)
                .HasMaxLength(100)
                .HasColumnName("to_nev");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
