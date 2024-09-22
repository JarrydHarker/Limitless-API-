using System;
using System.Collections.Generic;

namespace OPSCAPI.Models;

public partial class TblFood
{
    public string FoodId { get; set; } = null!;

    public string? MealId { get; set; }

    public string Category { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double? Weight { get; set; }

    public int Calories { get; set; }

    public double? Protein { get; set; }

    public double? Carbohydrates { get; set; }

    public double? Fibre { get; set; }

    public double? Fat { get; set; }

    public double? Cholestrol { get; set; }

    public double? Sugar { get; set; }

    public double? SaturatedFat { get; set; }

    public double? VitaminB12 { get; set; }

    public double? VitaminB6 { get; set; }

    public double? VitaminK { get; set; }

    public double? VitaminE { get; set; }

    public double? VitaminC { get; set; }

    public double? VitaminA { get; set; }

    public double? Zinc { get; set; }

    public double? Magnesium { get; set; }

    public double? Sodium { get; set; }

    public double? Potassium { get; set; }

    public double? Iron { get; set; }

    public double? Calcium { get; set; }

    public virtual TblMeal? Meal { get; set; }
}
