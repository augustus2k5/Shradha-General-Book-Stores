using System;
using System.Collections.Generic;

namespace Eproject2025.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public string? CustomerName { get; set; }

    public string? Email { get; set; }

    public string? Message { get; set; }

    public DateTime? CreatedAt { get; set; }
}
