using System;
using System.Collections.Generic;

namespace OPSCAPI.Models;

public partial class TblCardioExercise
{
    public string ExerciseId { get; set; } = null!;

    public int Time { get; set; }

    public double Distance { get; set; }

    public virtual TblExercise? TblExercise { get; set; }
}
