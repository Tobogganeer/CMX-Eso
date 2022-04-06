using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMX.Instructions
{
    public class SdeInstruction : Instruction
    {
        public SdeInstruction(string internalID, InsValueType nextInsValueType) : base(internalID, nextInsValueType) { }

        //-sde // decreases the stack pointer
        public override void Execute()
        {
            Data.StackPointer--;
        }

        public override string GetDescription()
        {
            return "-sde // decreases the stack pointer";
        }
    }
}
