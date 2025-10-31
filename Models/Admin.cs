using System;
using System.Collections.Generic;

namespace Eproject2025.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public int? UserId { get; set; }

    public virtual UserAccount? User { get; set; }
}
