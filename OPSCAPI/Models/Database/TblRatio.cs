using System;
using System.Collections.Generic;

namespace OPSCAPI.Models.Database;

public partial class TblRatio
{
    public string UserId { get; set; } = null!;

    public double Protein { get; set; }

    public double Carbs { get; set; }

    public double Fibre { get; set; }

    public double Fat { get; set; }

    public virtual TblUserInfo User { get; set; } = null!;
}
