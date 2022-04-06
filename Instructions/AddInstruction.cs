using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMX.Instructions
{
    public class AddInstruction : Instruction
    {
        public AddInstruction(string internalID, InsValueType nextInsValueType) : base(internalID, nextInsValueType) { }

        //-add (ptr, amount) // adds amount to ptr and loads into current stack ptr
        public override void Execute()
        {
            byte ptr = Data.GetP(1);
            byte valueAtPtr = Data.Get(ptr);
            byte amount = Data.GetP(2);
            Data.SetP(valueAtPtr.Add(amount));
        }

        public override string GetDescription()
        {
            return "-add (ptr, amount) // adds amount to ptr and loads into current stack ptr";
        }
    }
}
