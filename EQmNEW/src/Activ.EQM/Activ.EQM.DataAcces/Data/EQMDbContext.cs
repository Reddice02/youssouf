using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace Activ.EQM.DataAcces.Data
{
    using Models;
    using Contacts;
    
    public partial class EQMDbContext : DbContext
    {  
        public EQMDbContext()
        {
        }

        public EQMDbContext(DbContextOptions<EQMDbContext> options)
            : base(options)  {
        }

        public virtual DbSet<EqmActionPlan> EqmActionPlans { get; set; }
        public virtual DbSet<EqmActionPoint> EqmActionPoints { get; set; }
        public virtual DbSet<EqmActionPointNature> EqmActionPointNatures { get; set; }
        public virtual DbSet<EqmAudit> EqmAudits { get; set; }
        public virtual DbSet<EqmProcess> EqmProcesses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=Q;Database=EQM;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EqmActionPlan>(entity =>
            {
                entity.HasKey(e => e.ActionPlanId);

                entity.ToTable("EQM_ActionPlan");

                entity.Property(e => e.ActionPlanId).HasColumnName("ActionPlanID");

                entity.Property(e => e.ActionPointId).HasColumnName("ActionPointID");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.EndDateEffective).HasColumnType("datetime");

                entity.Property(e => e.EndDateExpected).HasColumnType("datetime");

                entity.Property(e => e.Manager)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StartDateEffective).HasColumnType("datetime");

                entity.Property(e => e.StartDateExpected).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActionPoint)
                    .WithMany(p => p.EqmActionPlans)
                    .HasForeignKey(d => d.ActionPointId)
                    .HasConstraintName("FK_EQM_ActionPlan_EQM_ActionPoint");
            });

            modelBuilder.Entity<EqmActionPoint>(entity =>
            {
                entity.HasKey(e => e.ActionPointId);

                entity.ToTable("EQM_ActionPoint");

                entity.Property(e => e.ActionPointId).HasColumnName("ActionPointID");

                entity.Property(e => e.AuditId).HasColumnName("AuditID");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.NatureId).HasColumnName("NatureID");

                entity.Property(e => e.ThirdPartyProcessStep).HasColumnType("text");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Audit)
                    .WithMany(p => p.EqmActionPoints)
                    .HasForeignKey(d => d.AuditId)
                    .HasConstraintName("FK_EQM_ActionPoint_EQM_Audit");

                entity.HasOne(d => d.Nature)
                    .WithMany(p => p.EqmActionPoints)
                    .HasForeignKey(d => d.NatureId)
                    .HasConstraintName("FK_EQM_ActionPoint_EQM_ActionPointNature");
            });

            modelBuilder.Entity<EqmActionPointNature>(entity =>
            {
                entity.HasKey(e => e.NatureId);

                entity.ToTable("EQM_ActionPointNature");

                entity.Property(e => e.NatureId).HasColumnName("NatureID");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EqmAudit>(entity =>
            {
                entity.HasKey(e => e.AuditId);

                entity.ToTable("EQM_Audit");

                entity.Property(e => e.AuditId).HasColumnName("AuditID");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.EndDateEffective).HasColumnType("datetime");

                entity.Property(e => e.EndDateExpected).HasColumnType("datetime");

                entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.Property(e => e.Reference)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Report).HasColumnType("text");

                entity.Property(e => e.StartDateEffective).HasColumnType("datetime");

                entity.Property(e => e.StartDateExpected).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.EqmAudits)
                    .HasForeignKey(d => d.ProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EQM_Audit_EQM_Process");
            });

            modelBuilder.Entity<EqmProcess>(entity =>
            {
                entity.HasKey(e => e.ProcessId);

                entity.ToTable("EQM_Process");

                entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Manager)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Participants).HasColumnType("text");

                entity.Property(e => e.ThirdPartyProcesses).HasColumnType("text");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
