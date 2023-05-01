using System;
using System.Collections.Generic;

namespace aquaparko;

public partial class Type
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Food> Foods { get; } = new List<Food>();
}
