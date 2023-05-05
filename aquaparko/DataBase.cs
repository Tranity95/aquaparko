using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aquaparko
{
    public class DataBase
    {
        static AquaparkoContext peremennaya;
        public static AquaparkoContext GetInstance()
        {
            if (peremennaya == null)
                peremennaya = new AquaparkoContext();
            return peremennaya;
        }
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
