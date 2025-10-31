using System;
using System.Collections.Generic;

namespace Eproject2025.Models;

public partial class Cddetail
{
    public string ProductId { get; set; } = null!;

    public string? Artist { get; set; }

    public string? Genre { get; set; }

    public int? DurationMinutes { get; set; }

    public int? CapacityMb { get; set; }

    public string? CdType { get; set; }

    public virtual Product Product { get; set; } = null!;
}
