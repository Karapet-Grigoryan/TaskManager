using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.DAL.TaskManagerModel;

public partial class TaskManagerContext : DbContext
{
    public TaskManagerContext()
    {
    }

    public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PriorityLevel> PriorityLevels { get; set; }

    public virtual DbSet<TaskStatus> TaskStatuses { get; set; }

    public virtual DbSet<TodoTask> TodoTasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=LAPTOP-2QCJNSK3;Database=TaskManager;Trusted_Connection=True;TrustServerCertificate=True;");
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PriorityLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Priority__3214EC07DB41F5A7");

            entity.ToTable("PriorityLevel");

            entity.HasIndex(e => e.Name, "UQ__Priority__737584F6F9DD9CD9").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ColorHexCode).HasMaxLength(7);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TaskStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaskStat__3214EC076F2D2487");

            entity.ToTable("TaskStatus");

            entity.HasIndex(e => e.Name, "UQ__TaskStat__737584F6CBE8CF30").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TodoTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TodoTask__3214EC079DC1CF23");

            entity.ToTable("TodoTask");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.PriorityId).HasDefaultValue(2);
            entity.Property(e => e.StatusId).HasDefaultValue(1);
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Priority).WithMany(p => p.TodoTasks)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TodoTask_PriorityLevel");

            entity.HasOne(d => d.Status).WithMany(p => p.TodoTasks)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TodoTask_TaskStatus");

            entity.HasOne(d => d.User).WithMany(p => p.TodoTasks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_TodoTask_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC075D031EC5");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D1053457B75673").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__User__C9F2845613599AA2").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
