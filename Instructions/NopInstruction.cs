using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMX.Instructions
{
    public class NopInstruction : Instruction
    {
        public NopInstruction(string internalID, InsValueType nextInsValueType) : base(internalID, nextInsValueType) { }

        public override void Execute()
        {
            // Execute
        }

        public override string GetDescription()
        {
            return "no operation";
        }
    }
}
