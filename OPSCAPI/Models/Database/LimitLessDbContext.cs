using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace OPSCAPI.Models.Database;

public partial class LimitlessDbContext : DbContext
{
    public LimitlessDbContext()
    {
    }

    public LimitlessDbContext(DbContextOptions<LimitlessDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCardioExercise> TblCardioExercises { get; set; }

    public virtual DbSet<TblDay> TblDays { get; set; }

    public virtual DbSet<TblExercise> TblExercises { get; set; }

    public virtual DbSet<TblFood> TblFoods { get; set; }

    public virtual DbSet<TblMeal> TblMeals { get; set; }

    public virtual DbSet<TblMealFood> TblMealFoods { get; set; }

    public virtual DbSet<TblMovement> TblMovements { get; set; }

    public virtual DbSet<TblRatio> TblRatios { get; set; }

    public virtual DbSet<TblStrengthExercise> TblStrengthExercises { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblUserInfo> TblUserInfos { get; set; }

    public virtual DbSet<TblWorkout> TblWorkouts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:opscserver.database.windows.net,1433;Initial Catalog=LimitlessDB;Persist Security Info=False;User ID=ST10085210;Password=Treepair521;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<TblCardioExercise>(entity =>
        {
            entity.HasKey(e => e.ExerciseId).HasName("PK_tblCardio");

            entity.ToTable("tblCardioExercise");

            entity.Property(e => e.ExerciseId)
                .ValueGeneratedNever()
                .HasColumnName("ExerciseID");
        });

        modelBuilder.Entity<TblDay>(entity =>
        {
            entity.HasKey(e => new { e.Date, e.UserId });

            entity.ToTable("tblDay");

            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.TblDays)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblDay_tblUser");
        });

        modelBuilder.Entity<TblExercise>(entity =>
        {
            entity.HasKey(e => e.ExerciseId);

            entity.ToTable("tblExercise");

            entity.Property(e => e.ExerciseId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ExerciseID");
            entity.Property(e => e.MovementId).HasColumnName("MovementID");
            entity.Property(e => e.WorkoutId).HasColumnName("WorkoutID");

            entity.HasOne(d => d.Exercise).WithOne(p => p.TblExercise)
                .HasForeignKey<TblExercise>(d => d.ExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblExercise_tblCardio");

            entity.HasOne(d => d.ExerciseNavigation).WithOne(p => p.TblExercise)
                .HasForeignKey<TblExercise>(d => d.ExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblExercise_tblStrength");

            entity.HasOne(d => d.Movement).WithMany(p => p.TblExercises)
                .HasForeignKey(d => d.MovementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblExercise_tblMovement");

            entity.HasOne(d => d.Workout).WithMany(p => p.TblExercises)
                .HasForeignKey(d => d.WorkoutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblExercise_tblWorkout");
        });

        modelBuilder.Entity<TblFood>(entity =>
        {
            entity.HasKey(e => e.FoodId);

            entity.ToTable("tblFood");

            entity.Property(e => e.FoodId).HasColumnName("FoodID");
            entity.Property(e => e.Category).HasMaxLength(250);
        });

        modelBuilder.Entity<TblMeal>(entity =>
        {
            entity.HasKey(e => e.MealId);

            entity.ToTable("tblMeal");

            entity.Property(e => e.MealId).HasColumnName("MealID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TblMealFood>(entity =>
        {
            entity.HasKey(e => new { e.MealId, e.FoodId, e.Date });

            entity.ToTable("tblMeal_Food");

            entity.Property(e => e.MealId).HasColumnName("MealID");
            entity.Property(e => e.FoodId).HasColumnName("FoodID");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UserID");

            entity.HasOne(d => d.Food).WithMany(p => p.TblMealFoods)
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblMeal_Food_tblFood");

            entity.HasOne(d => d.Meal).WithMany(p => p.TblMealFoods)
                .HasForeignKey(d => d.MealId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblMeal_Food_tblMeal");

            entity.HasOne(d => d.TblDay).WithMany(p => p.TblMealFoods)
                .HasForeignKey(d => new { d.Date, d.UserId })
                .HasConstraintName("FK_tblMeal_Food_tblDay");
        });

        modelBuilder.Entity<TblMovement>(entity =>
        {
            entity.HasKey(e => e.MovementId);

            entity.ToTable("tblMovement");

            entity.Property(e => e.MovementId).HasColumnName("MovementID");
            entity.Property(e => e.Bodypart).HasMaxLength(20);
            entity.Property(e => e.DifficultyLevel).HasMaxLength(25);
            entity.Property(e => e.Equipment).HasMaxLength(25);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(25);
        });

        modelBuilder.Entity<TblRatio>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_tblRatios_1");

            entity.ToTable("tblRatios");

            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithOne(p => p.TblRatio)
                .HasForeignKey<TblRatio>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblRatios_tblUserInfo");
        });

        modelBuilder.Entity<TblStrengthExercise>(entity =>
        {
            entity.HasKey(e => e.ExerciseId).HasName("PK_tblStrength");

            entity.ToTable("tblStrengthExercise");

            entity.Property(e => e.ExerciseId)
                .ValueGeneratedNever()
                .HasColumnName("ExerciseID");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("tblUser");

            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<TblUserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("tblUserInfo");

            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithOne(p => p.TblUserInfo)
                .HasForeignKey<TblUserInfo>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblUserInfo_tblUser");
        });

        modelBuilder.Entity<TblWorkout>(entity =>
        {
            entity.HasKey(e => e.WorkoutId);

            entity.ToTable("tblWorkout");

            entity.Property(e => e.WorkoutId).HasColumnName("WorkoutID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UserID");

            entity.HasOne(d => d.TblDay).WithMany(p => p.TblWorkouts)
                .HasForeignKey(d => new { d.Date, d.UserId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblWorkout_tblDay");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
