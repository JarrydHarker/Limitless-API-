using System;
using System.Collections.Generic;

namespace OPSCAPI.Models;

public partial class TblUser
{
    public string UserId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public double? WeightGoal { get; set; }

    public double? CalorieWallet { get; set; }

    public int StepGoal { get; set; }

    public virtual ICollection<TblDay> TblDays { get; set; } = new List<TblDay>();
}
