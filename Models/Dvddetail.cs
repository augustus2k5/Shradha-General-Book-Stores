using System;
using System.Collections.Generic;

namespace Eproject2025.Models;

public partial class Dvddetail
{
    public string ProductId { get; set; } = null!;

    public string? Director { get; set; }

    public string? Genre { get; set; }

    public int? DurationMinutes { get; set; }

    public string? RegionCode { get; set; }

    public string? DvdType { get; set; }

    public virtual Product Product { get; set; } = null!;
}
