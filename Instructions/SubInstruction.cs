using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMX.Instructions
{
    public class SubInstruction : Instruction
    {
        public SubInstruction(string internalID, InsValueType nextInsValueType) : base(internalID, nextInsValueType) { }

        //-sub (ptr, amount) // subs amount from ptr and loads into current stack ptr
        public override void Execute()
        {
            byte ptr = Data.GetP(1);
            byte valueAtPtr = Data.Get(ptr);
            byte amount = Data.GetP(2);
            Data.SetP(valueAtPtr.Sub(amount));
        }

        public override string GetDescription()
        {
            return "-sub (ptr, amount) // subs amount from ptr and loads into current stack ptr";
        }
    }
}
