using System;
using System.Collections.Generic;

namespace Eproject2025.Models;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string SubcategoryId { get; set; } = null!;

    public int PublisherId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Manufacturer { get; set; }

    public decimal? Price { get; set; }

    public string? Type { get; set; }

    public int? Stock { get; set; }

    public string? ImageUrl { get; set; }

    public virtual BookDetail? BookDetail { get; set; }

    public virtual Cddetail? Cddetail { get; set; }

    public virtual Dvddetail? Dvddetail { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Publisher Publisher { get; set; } = null!;

    public virtual SubCategory Subcategory { get; set; } = null!;
}
