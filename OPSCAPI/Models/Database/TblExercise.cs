using System;
using System.Collections.Generic;

namespace OPSCAPI.Models.Database;

public partial class TblExercise
{
    public string ExerciseId { get; set; } = null!;

    public string WorkoutId { get; set; } = null!;

    public int MovementId { get; set; }

    public virtual TblCardioExercise Exercise { get; set; } = null!;

    public virtual TblStrengthExercise ExerciseNavigation { get; set; } = null!;

    public virtual TblMovement Movement { get; set; } = null!;

    public virtual TblWorkout Workout { get; set; } = null!;
}
