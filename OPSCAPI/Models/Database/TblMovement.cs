using System;
using System.Collections.Generic;

namespace OPSCAPI.Models.Database;

public partial class TblMovement
{
    public string MovementId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Type { get; set; } = null!;

    public string Bodypart { get; set; } = null!;

    public string Equipment { get; set; } = null!;

    public string DifficultyLevel { get; set; } = null!;

    public double? Max { get; set; }

    public virtual ICollection<TblExercise> TblExercises { get; set; } = new List<TblExercise>();
}
