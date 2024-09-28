using System;
using System.Collections.Generic;

namespace OPSCAPI.Models.Database;

public partial class TblMeal
{
    public int MealId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TblMealFood> TblMealFoods { get; set; } = new List<TblMealFood>();

    
}
