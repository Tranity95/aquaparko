using System;
using System.Collections.Generic;

namespace aquaparko;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? SurName { get; set; }

    public int? RoleId { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual Role? Role { get; set; }

    public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();
}
