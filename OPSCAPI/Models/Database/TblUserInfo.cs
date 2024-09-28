using System;
using System.Collections.Generic;

namespace OPSCAPI.Models.Database;

public partial class TblUserInfo
{
    public string UserId { get; set; } = null!;

    public double? Height { get; set; }

    public double? Weight { get; set; }

    public double? WeightGoal { get; set; }

    public double CalorieWallet { get; set; }

    public double StepGoal { get; set; }

    public virtual TblRatio? TblRatio { get; set; }

    public virtual TblUser User { get; set; } = null!;

   
}
