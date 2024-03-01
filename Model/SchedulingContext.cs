using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchedulingApi.Model;

public partial class SchedulingContext : DbContext
{
    public SchedulingContext()
    {
    }

    public SchedulingContext(DbContextOptions<SchedulingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Meeting> Meetings { get; set; }

    public virtual DbSet<MeetingParticipant> MeetingParticipants { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Meeting>(entity =>
        {
            entity.ToTable("Meeting");

            entity.Property(e => e.MeetingId)
                .HasColumnType("INT");
        });

        modelBuilder.Entity<MeetingParticipant>(entity =>
        {
            entity.HasKey(e => new { e.MeetingId, e.UserId });

            entity.Property(e => e.MeetingId).HasColumnType("INT");
            entity.Property(e => e.UserId).HasColumnType("INT");

            entity.HasOne(d => d.Meeting).WithMany(p => p.MeetingParticipants).HasForeignKey(d => d.MeetingId);

            entity.HasOne(d => d.MeetingNavigation).WithMany(p => p.MeetingParticipants).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
