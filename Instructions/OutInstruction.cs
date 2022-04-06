using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMX.Instructions
{
    public class OutInstruction : Instruction
    {
        public OutInstruction(string internalID, InsValueType nextInsValueType) : base(internalID, nextInsValueType) { }

        //-out (length) // outputs the amount of characters set at the value of the stack pointer
        public override void Execute()
        {
            byte length = Data.GetP();

            char[] str = new char[length];

            for (byte i = 0; i < length; i++)
            {
                str[i] = GetLetter(Data.GetP(i + 1));
            }

            Console.WriteLine(new string(str));
        }

        private char GetLetter(byte value)
        {
            // Temp
            //return value.ToString()[0];

            return ChemexCharacters.ToChar(value);
        }

        public override string GetDescription()
        {
            return "-out (length) // outputs the amount of characters set at the value of the stack pointer";
        }
    }
}
