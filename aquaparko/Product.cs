using System;
using System.Collections.Generic;

namespace aquaparko;

public partial class Product
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Food> Foods { get; } = new List<Food>();

    public virtual ICollection<Provider> Providers { get; } = new List<Provider>();
}
