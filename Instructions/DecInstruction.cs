using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMX.Instructions
{
    public class DecInstruction : Instruction
    {
        public DecInstruction(string internalID, InsValueType nextInsValueType) : base(internalID, nextInsValueType) { }

        //-dec // decreases the value of the stack ptr by the value of the next instruction
        public override void Execute()
        {
            //if (Code.instructions.Count - 1 >= Code.InstructionIndex)
            //{
            //    Console.WriteLine("o shite cannot read next instruction, it doesnt exist lol. some things boutta break badly");
            //    return;
            //}
            byte nextIns = Code.instructions[Code.InstructionIndex + 1];
            Data.StackPointer -= nextIns;
        }

        public override string GetDescription()
        {
            return "-dec // decreases the value of the stack ptr by the value of the next instruction";
        }
    }
}
