using System;
using System.Collections.Generic;

namespace aquaparko;

public partial class Role
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
