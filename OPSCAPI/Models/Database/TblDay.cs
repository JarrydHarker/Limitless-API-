using System;
using System.Collections.Generic;

namespace OPSCAPI.Models.Database;

public partial class TblDay
{
    public DateOnly Date { get; set; }

    public string UserId { get; set; } = null!;

    public int Steps { get; set; }

    public double Calories { get; set; }

    public double? Weight { get; set; }

    public int ActiveTime { get; set; }

    public double Water { get; set; }

    public virtual ICollection<TblMealFood> TblMealFoods { get; set; } = new List<TblMealFood>();

    public virtual ICollection<TblWorkout> TblWorkouts { get; set; } = new List<TblWorkout>();

    public virtual TblUser User { get; set; } = null!;
}
