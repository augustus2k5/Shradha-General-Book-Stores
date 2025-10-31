using System;
using System.Collections.Generic;

namespace Eproject2025.Models;

public partial class BookDetail
{
    public string ProductId { get; set; } = null!;

    public string? Author { get; set; }

    public string? Isbn { get; set; }

    public int? Pages { get; set; }

    public string? Language { get; set; }

    public int? PublicationYear { get; set; }

    public virtual Product Product { get; set; } = null!;
}
