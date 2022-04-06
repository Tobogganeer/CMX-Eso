using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMX.Instructions
{
    public class GotInstruction : Instruction
    {
        public GotInstruction(string internalID, InsValueType nextInsValueType) : base(internalID, nextInsValueType) { }

        //-got (ptr) // moves stack pointer to ptr
        public override void Execute()
        {
            Data.StackPointer = Data.GetP(1);
        }

        public override string GetDescription()
        {
            return "-got (ptr) // moves stack pointer to ptr";
        }
    }
}
