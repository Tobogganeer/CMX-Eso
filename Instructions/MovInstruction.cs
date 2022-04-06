using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMX.Instructions
{
    public class MovInstruction : Instruction
    {
        public MovInstruction(string internalID, InsValueType nextInsValueType) : base(internalID, nextInsValueType) { }

        //-mov (from_ptr, to_ptr) // moves a value from from_ptr to to_ptr
        public override void Execute()
        {
            byte from = Data.GetP(1);
            byte to = Data.GetP(2);
            Data.Set(to, Data.Get(from));
        }

        public override string GetDescription()
        {
            return "-mov (from_ptr, to_ptr) // moves a value from from_ptr to to_ptr";
        }
    }
}
