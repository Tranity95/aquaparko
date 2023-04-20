using System;
using System.Collections.Generic;

namespace aquaparko;

public partial class Provider
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
