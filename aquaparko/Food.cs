using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace aquaparko;

public partial class Food
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? Type { get; set; }

    public int? Price { get; set; }

    public string? Image { get; set; }

    [NotMapped]
    public string ImagePath { get => Environment.CurrentDirectory + Image; }

    public virtual Type? TypeNavigation { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
    public string ProductsList
    {
        get
        {
            return string.Join(", ", Products.Select(s => s.Title));
        }
    }
}
