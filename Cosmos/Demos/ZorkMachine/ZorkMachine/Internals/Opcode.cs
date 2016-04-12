using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZorkMachine.Internals.Opcodes;

namespace ZorkMachine.Internals
{
    public class Operand
    {
        public byte Operands_1 { get; set; }
        public byte Operands_2 { get; set; }
    }

    public abstract class Opcode
    {
        public static List<Opcode> Opcodes = new List<Opcode>() {
            new Call()
        };

        public static Opcode ParseOpcode(ZorkStream z)
        {
            var b = z.ReadByte();
            foreach (var i in Opcodes)
            {
                if(i.IsMe(b))
                {
                    return i.Parse(z);
                }
            }
            return null;
        }

        public byte Opcode_1 { get; set; }
        public byte Opcode_2 { get; set; }
        public byte TypesOperands_1 { get; set; }
        public byte TypesOperands_2 { get; set; }
        public Operand[] Operands { get; set; } = new Operand[8];
        public byte StoreVriable { get; set; }
        public byte BranchOffset_1 { get; set; }
        public byte BranchOffset_2 { get; set; }
        public string TextToPrint { get; set; }



        public virtual bool IsMe(byte a) { return false; }
        public virtual Opcode Parse(ZorkStream z) { return null; }
    }


    /*
        All the Opcodes
    */

    //public class 
}
