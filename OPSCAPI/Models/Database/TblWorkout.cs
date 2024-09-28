using System;
using System.Collections.Generic;

namespace OPSCAPI.Models.Database;

public partial class TblWorkout
{
    public int WorkoutId { get; set; }

    public DateOnly Date { get; set; }

    public string UserId { get; set; } = null!;

    public virtual TblDay TblDay { get; set; } = null!;

    public virtual ICollection<TblExercise> TblExercises { get; set; } = new List<TblExercise>();

    public TblWorkout()
    {
    }
}
