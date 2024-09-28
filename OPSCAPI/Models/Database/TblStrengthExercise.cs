using System;
using System.Collections.Generic;

namespace OPSCAPI.Models.Database;

public partial class TblStrengthExercise
{
    public int ExerciseId { get; set; }

    public int Sets { get; set; }

    public int Repetitions { get; set; }

    public bool Favourite { get; set; }

    public virtual TblExercise? TblExercise { get; set; }

    
}
