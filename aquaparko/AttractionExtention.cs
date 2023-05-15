using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aquaparko
{
    public partial class Attraction
    {
        [NotMapped]

        public string ImagePath { get => Environment.CurrentDirectory + Image; }

        [NotMapped]
        public string ScaryLvlString { get => ScaryLvl + " из 10"; }

    }
}
