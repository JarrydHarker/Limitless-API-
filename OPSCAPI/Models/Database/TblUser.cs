using System;
using System.Collections.Generic;

namespace OPSCAPI.Models.Database;

public partial class TblUser
{
    public string UserId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<TblDay> TblDays { get; set; } = new List<TblDay>();

    public virtual TblUserInfo? TblUserInfo { get; set; }
}
