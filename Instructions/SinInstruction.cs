using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMX.Instructions
{
    public class SinInstruction : Instruction
    {
        public SinInstruction(string internalID, InsValueType nextInsValueType) : base(internalID, nextInsValueType) { }

        //-sin // increases the stack pointer
        public override void Execute()
        {
            Data.StackPointer++;
        }

        public override string GetDescription()
        {
            return "-sin // increases the stack pointer";
        }
    }
}
