using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aquaparko
{
    public partial class Sauna
    {
        [NotMapped]
        public string ImagePath { get => Environment.CurrentDirectory + Image; }

    }
}
