using System;
using System.Collections.Generic;

namespace OPSCAPI.Models.Database;

public partial class TblMealFood
{
    public string MealId { get; set; } = null!;

    public int FoodId { get; set; }

    public virtual TblFood Food { get; set; } = null!;

    public virtual TblMeal Meal { get; set; } = null!;
}
