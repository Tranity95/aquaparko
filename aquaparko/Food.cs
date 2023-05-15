using System;
using System.Collections.Generic;

namespace aquaparko;

public partial class Food
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? Type { get; set; }

    public int? Price { get; set; }

    public string? Image { get; set; }

    public string? Descreption { get; set; }

    public virtual Type? TypeNavigation { get; set; }


}
