using System;
using System.Collections.Generic;

namespace aquaparko;

public partial class Ticket
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
