using System.Collections.Generic;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    // Navigation property
    public virtual ICollection<Order> Orders { get; set; }
}