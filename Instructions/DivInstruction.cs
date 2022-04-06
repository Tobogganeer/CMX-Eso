using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMX.Instructions
{
    public class DivInstruction : Instruction
    {
        public DivInstruction(string internalID, InsValueType nextInsValueType) : base(internalID, nextInsValueType) { }

        //-div (ptr, amount) // divs ptr by amount and loads into current stack ptr
        public override void Execute()
        {
            byte ptr = Data.GetP(1);
            byte valueAtPtr = Data.Get(ptr);
            byte amount = Data.GetP(2);
            Data.SetP(valueAtPtr.Div(amount));
        }

        public override string GetDescription()
        {
            return "-div (ptr, amount) // divs ptr by amount and loads into current stack ptr";
        }
    }
}
