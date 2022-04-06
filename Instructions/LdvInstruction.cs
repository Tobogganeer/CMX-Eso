using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMX.Instructions
{
    public class LdvInstruction : Instruction
    {
        public LdvInstruction(string internalID, InsValueType nextInsValueType) : base(internalID, nextInsValueType) { }

        //-ldv // loads the value of the next instruction into the current stack ptr
        public override void Execute()
        {
            //if (Code.instructions.Count - 1 >= Code.InstructionIndex)
            //{
            //    Console.WriteLine("o shite cannot read next instruction, it doesnt exist lol. some things boutta break badly");
            //    return;
            //}
            byte nextIns = Code.instructions[Code.InstructionIndex + 1];
            Data.SetP(nextIns);
        }

        public override string GetDescription()
        {
            return "-ldv // loads the value of the next instruction into the current stack ptr";
        }
    }
}
