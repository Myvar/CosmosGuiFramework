using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkMachine.Internals.Opcodes
{
    public class Call : Opcode
    {
        public override bool IsMe(byte a)
        {
            if(a == 224)
            {
                return true;
            }
            return false;
        }

        public override Opcode Parse(ZorkStream z)
        {
            var re = new Call();
            re.BranchOffset_1 = 50;
            return re;
        }
    }
}
