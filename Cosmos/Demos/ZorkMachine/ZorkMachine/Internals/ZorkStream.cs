using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkMachine.Internals
{
    public  class ZorkStream
    {
        private List<byte> _buffer = new List<byte>();
        public int _index = -1;

        public ZorkStream(byte[] raw)
        {
            for (int i = 0; i < raw.Length; i++)
            {
                _buffer.Add(raw[i]);
            }
        }

        public ZorkStream(byte[] raw, int offset)
        {
            for (int i = 0; i < raw.Length; i++)
            {
                _buffer.Add(raw[i]);
            }
            _index = offset - 1;
        }

        public byte ReadByte()
        {
            _index++;
           return _buffer[_index];
        }

        public byte ReadByte(int addr)
        {            
            return _buffer[addr];
        }

        public short ReadShort()
        {
            var a = ReadByte();
            var b = ReadByte();
            return (short)((a << 8) | b);
        }

        public short ReadShort(int addr)
        {
            var a = ReadByte(addr);
            var b = ReadByte(addr + 1);
            return (short)((a << 8) | b);
        }
    }
}
