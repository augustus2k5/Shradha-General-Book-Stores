using System;
using System.Collections.Generic;

namespace Eproject2025.Models;

public partial class SubCategory
{
    public string SubcategoryId { get; set; } = null!;

    public string CategoryId { get; set; } = null!;

    public string? Manufacturer { get; set; }

    public string? SubcategoryName { get; set; }

    public string? Status { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
