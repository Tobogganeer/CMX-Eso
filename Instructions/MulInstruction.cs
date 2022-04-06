using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMX.Instructions
{
    public class MulInstruction : Instruction
    {
        public MulInstruction(string internalID, InsValueType nextInsValueType) : base(internalID, nextInsValueType) { }

        //-mul (ptr, amount) // mult amount with ptr and loads into current stack ptr
        public override void Execute()
        {
            byte ptr = Data.GetP(1);
            byte valueAtPtr = Data.Get(ptr);
            byte amount = Data.GetP(2);
            Data.SetP(valueAtPtr.Mul(amount));
        }

        public override string GetDescription()
        {
            return "-mul (ptr, amount) // mult amount with ptr and loads into current stack ptr";
        }
    }
}
