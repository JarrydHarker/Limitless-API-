using System;
using System.Collections.Generic;

namespace OPSCAPI.Models;

public partial class TblStrengthExercise
{
    public string ExerciseId { get; set; } = null!;

    public int Sets { get; set; }

    public int Repetitions { get; set; }

    public bool Favourite { get; set; }

    public virtual TblExercise? TblExercise { get; set; }
}
