using Cosmos.IL2CPU.Plugs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGF.System.Plugs
{
    [Plug(Target = typeof(Dictionary<uint, int>))]
    public static class DictionaryImpl
    {

        public static void Ctor(Dictionary<uint, int> aThis, int capacity, IEqualityComparer<int> comparer)
        {
            if (capacity != 0)
            {
                throw new Exception("Capacity != 0 not supported yet!");
            }

        }

    }

}
