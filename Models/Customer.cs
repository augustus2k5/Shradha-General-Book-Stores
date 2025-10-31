using System;
using System.Collections.Generic;

namespace Eproject2025.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public int? UserId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public decimal? DistanceKm { get; set; }

    public virtual UserAccount? User { get; set; }
}
