using System;
using System.Collections.Generic;

namespace OPSCAPI.Models;

public partial class TblExercise
{
    public int ExerciseId { get; set; }

    public int WorkoutId { get; set; }

    public int MovementId { get; set; }

    public virtual TblCardioExercise Exercise { get; set; } = null!;

    public virtual TblStrengthExercise ExerciseNavigation { get; set; } = null!;

    public virtual TblMovement Movement { get; set; } = null!;

    public virtual TblWorkout Workout { get; set; } = null!;
}
