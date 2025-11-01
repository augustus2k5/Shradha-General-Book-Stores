using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eproject2025.Models;

public partial class Category
{
    public string CategoryId { get; set; } = null!;
    [Required]
    public string CategoryName { get; set; } = null!;
    [Required]
    public string? Description { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
}
