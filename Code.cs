using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMX
{
    public static class Code
    {
        private const int LIST_INIT_AMOUNT = 32;
        public static readonly List<byte> instructions = new List<byte>(LIST_INIT_AMOUNT);

        public static int InstructionIndex { get; private set; }

        public static void LoadChemexCodes(string file)
        {
            string[] chemexCodes = file.Split(' ', '\n');

            instructions.Clear();

            foreach (string rawCode in chemexCodes)
            {
                string code = rawCode.Replace("\n", "").Trim();

                if (ChemexConvertor.IsChemexCode(code))
                    instructions.Add(ChemexConvertor.ToNumber(code));
            }
        }

        public static void LoadInternalCodes(string file)
        {
            string[] internalCodes = file.Split(' ', '\n');

            instructions.Clear();

            foreach (string rawCode in internalCodes)
            {
                string code = rawCode.Replace("\n", "").Trim();

                if (code.Length == 0) return;

                if (code.Length == 1 && !char.IsDigit(code[0]))
                    instructions.Add(ChemexCharacters.ToByte(code[0]));

                else if (char.IsDigit(code[0]))
                {
                    byte num = byte.Parse(code);
                    if (num > 63)
                    {
                        Console.Write("Invalid numerical instruction, max size is 63");
                        num = 63;
                    }

                    instructions.Add(num);
                }

                else if (code == "space")
                    instructions.Add(ChemexCharacters.ToByte(' '));

                else
                    instructions.Add(OpCodeID.Get(code).OpCode);
            }
        }

        public static void LoadOpCodes(byte[] fileBytes)
        {
            instructions.Clear();

            foreach (byte opCode in fileBytes)
            {
                instructions.Add(opCode);
            }
        }

        public static void IncreaseInstructionIndex()
        {
            InstructionIndex++;
        }
    }
}
