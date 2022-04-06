using System;
using System.Collections.Generic;
using System.IO;

namespace CMX
{
    public static class CodeConvertor
    {
        public static void WriteLoadedCode()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "convertor_output");

            WriteCMX(path + ".cmx");
            WriteCMI(path + ".cmi");
            WriteCMB(path + ".cmb");
        }

        private static void WriteCMX(string fileName)
        {
            System.Text.StringBuilder output = new System.Text.StringBuilder();
            foreach (byte ins in Code.instructions)
            {
                output.AppendLine(ChemexConvertor.ToChemexCode(ins));
            }

            File.WriteAllText(fileName, output.ToString());
        }

        private static void WriteCMI(string fileName)
        {
            System.Text.StringBuilder output = new System.Text.StringBuilder();

            InsValueType nextInsType = InsValueType.None;

            foreach (byte ins in Code.instructions)
            {
                if (nextInsType == InsValueType.Byte)
                {
                    output.Append(ins.ToString() + "\n");
                    nextInsType = InsValueType.None;
                }

                else if (nextInsType == InsValueType.Char)
                {
                    char sym = ChemexCharacters.ToChar(ins);
                    if (sym == ' ')
                        output.Append("space" + "\n");
                    else
                        output.Append(sym + "\n");
                    nextInsType = InsValueType.None;
                }

                else if (nextInsType == InsValueType.None)
                {
                    Instruction instruction = Instruction.Get(ins);
                    nextInsType = instruction.NextInsValueType;

                    if (nextInsType == InsValueType.None)
                        output.Append(instruction.OpCodeID.InternalCode + "\n");
                    else
                        output.Append(instruction.OpCodeID.InternalCode + " ");
                }
            }

            File.WriteAllText(fileName, output.ToString());
        }

        private static void WriteCMB(string fileName)
        {
            File.WriteAllBytes(fileName, Code.instructions.ToArray());
        }
    }
}
