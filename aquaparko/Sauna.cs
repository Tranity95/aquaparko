using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace aquaparko;

public partial class Sauna
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Temperature { get; set; }

    public string? Humidity { get; set; }

    public int? Price { get; set; }

    public string? Image { get; set; }

    [NotMapped]
    public string ImagePath { get => Environment.CurrentDirectory + Image; }
}
