using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace aquaparko;

public partial class Attraction
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? ScaryLvl { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    [NotMapped]

    public string ImagePath { get => Environment.CurrentDirectory + Image; }

    [NotMapped]
    public string ScaryLvlString { get => ScaryLvl + " из 10"; }
}
