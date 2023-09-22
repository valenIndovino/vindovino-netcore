using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using vindovino_candidates.Models;

namespace vindovino_candidates.Database;

public partial class ValendbContext : DbContext
{
    public ValendbContext()
    {
    }

    public ValendbContext(DbContextOptions<ValendbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<Candidateexperience> Candidateexperiences { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => e.IdCandidate).HasName("PK__candidat__D5598973A000FA1C");

            entity.ToTable("candidates");

            entity.HasIndex(e => e.Email, "UQ__candidat__A9D10534E616ECE5").IsUnique();

            entity.Property(e => e.Birthdate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Candidateexperience>(entity =>
        {
            entity.HasKey(e => e.IdCandidateExperience).HasName("PK__candidat__D9A60D65E535F53F");

            entity.ToTable("candidateexperiences");

            entity.Property(e => e.BeginDate).HasColumnType("datetime");
            entity.Property(e => e.Company)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.Job)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Salary).HasColumnType("numeric(8, 2)");

            entity.HasOne(d => d.IdCandidateNavigation).WithMany(p => p.Candidateexperiences)
                .HasForeignKey(d => d.IdCandidate)
                .HasConstraintName("FK__candidate__IdCan__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
