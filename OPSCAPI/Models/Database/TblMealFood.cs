using System;
using System.Collections.Generic;

namespace OPSCAPI.Models.Database;

public partial class TblMealFood
{
    public int MealId { get; set; }

    public int FoodId { get; set; }

    public DateOnly Date { get; set; }

    public string? UserId { get; set; }

    public virtual TblFood Food { get; set; } = null!;

    public virtual TblMeal Meal { get; set; } = null!;

    public virtual TblDay? TblDay { get; set; }
}
