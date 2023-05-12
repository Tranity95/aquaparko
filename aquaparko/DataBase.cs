using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aquaparko
{
    public class DataBase
    {

        private static AquaparkoContext instance;

        public static AquaparkoContext Instance
        {
            get
            {
                if (instance == null)
                    instance = new AquaparkoContext();
                return instance;
            }
        }
    }
}
