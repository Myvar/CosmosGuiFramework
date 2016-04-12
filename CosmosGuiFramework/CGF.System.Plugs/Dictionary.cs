using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGF.System.Plugs
{
    public class Dictionary<TKey, TValue>
    {

        public TValue this[TKey val]
        {
            get
            {
                return default(TValue);
            }
            set
            {

            }

        }

        public bool TryGetValue(TKey key, out TValue current)
        {
            throw new NotImplementedException();
        }

        public void Add(TKey val, TValue glyphIndex)
        {
            throw new NotImplementedException();
        }
    }
}
