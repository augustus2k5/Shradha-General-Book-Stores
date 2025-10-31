using System;
using System.Collections.Generic;

namespace Eproject2025.Models;

public partial class Order
{
    public string OrderId { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? PaymentType { get; set; }

    public string? PaymentStatus { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? DeliveryCharge { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? Status { get; set; }

    public string? ShippingAddress { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual UserAccount User { get; set; } = null!;
}
