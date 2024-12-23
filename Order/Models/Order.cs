using System;
using System.Collections.Generic;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }

    // Foreign key
    public int UserId { get; set; }
    public virtual User User { get; set; }

    // Navigation property
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}