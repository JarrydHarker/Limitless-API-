using System;
using System.Collections.Generic;

namespace OPSCAPI.Models.Database;

public partial class TblMeal
{
    public string MealId { get; set; } = null!;

    public DateOnly? Date { get; set; }

    public string? UserId { get; set; }

    public string Name { get; set; } = null!;

    public virtual TblDay? TblDay { get; set; }
}
