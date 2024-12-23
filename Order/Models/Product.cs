using System.Collections.Generic;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    // Navigation property
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}