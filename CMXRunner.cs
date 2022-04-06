using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Stopwatch = System.Diagnostics.Stopwatch;

namespace CMX
{
    public static class CMXRunner
    {

        public static void Run()
        {
            Console.WriteLine($"CMX Interpreter v{Program.VERSION}\n");
            Console.WriteLine("Directory is " + Directory.GetCurrentDirectory());

            Console.WriteLine("Enter 'help', 'load filename' or 'quit'");

            string choice = Console.ReadLine();

            if (choice == "quit")
                return;

            if (choice.StartsWith("load "))
            {
                string fileName = choice.Split(' ', 2)[1];

                if (!CMXFile.LoadInstructions(fileName))
                {
                    Console.WriteLine("Could not locate file");
                }

                Console.WriteLine("'run', 'convert', or 'dump'?");

                choice = Console.ReadLine();

                if (choice == "run") RunLoadedCode();
                else if (choice == "convert") ConvertCode();
                else if (choice == "dump") DumpCode();

                //RunFile(fileName);
            }

            else if (choice == "help") LogHelp();

            else HandleCommand(choice);
        }

        private static void RunLoadedCode()
        {
            int maxSteps = 10000;

            Stopwatch timer = Stopwatch.StartNew();

            while (Code.InstructionIndex < Code.instructions.Count && maxSteps != 0)
            {
                maxSteps--;
                Instruction ins = Instruction.Get(Code.instructions[Code.InstructionIndex]);
                ins.Execute();

                Code.IncreaseInstructionIndex();
                if (ins.NextInsValueType != InsValueType.None)
                    Code.IncreaseInstructionIndex();
            }

            timer.Stop();

            Console.WriteLine("Finished execution in " + timer.ElapsedMilliseconds + "ms");
        }

        private static void ConvertCode()
        {
            Console.WriteLine("\nWriting to convertor_output.cmx/cmi/cmb ...");
            CodeConvertor.WriteLoadedCode();
        }

        private static void DumpCode()
        {
            bool logValue = false;

            foreach (byte opCode in Code.instructions)
            {
                if (logValue)
                {
                    Console.Write(" => value: " + opCode);
                    logValue = false;
                }
                else
                {
                    Instruction ins = Instruction.Get(opCode);
                    if (ins.NextInsValueType != InsValueType.None) logValue = true;

                    Console.Write("\n" + ins.OpCodeID.ToString());
                }
            }
        }

        private static void LogHelp()
        {
            Console.WriteLine("\n-load 'filename': Loads the specified CMX file (with out without extension) for running/converting/dumping");
            Console.WriteLine("-(byte): Logs the corresponding letter and instruction");
            Console.WriteLine("-(char): Logs the corresponding byte and instruction");
            Console.WriteLine("-(chemex code): Logs the corresponding opcode and instruction");
            Console.WriteLine("-(internal code): Logs the corresponding opcode and instruction");
            Console.WriteLine("-dump: Dumps all instructions");
        }

        private static void HandleCommand(string command)
        {
            if (command == "dump")
            {
                StringBuilder output = new StringBuilder();

                foreach (Instruction ins in Instruction.GetAllInstructions())
                {
                    output.AppendLine(" - " + ins.OpCodeID + " : " + ins.GetDescription());
                }

                Console.WriteLine(output.ToString());
                return;
            }

            if (ChemexConvertor.IsChemexCode(command))
            {
                byte uhChemexCodeAsByte = ChemexConvertor.ToNumber(command);
                Console.WriteLine($"\nDetails about {command}/{uhChemexCodeAsByte}/{ChemexCharacters.ToChar(uhChemexCodeAsByte)}\n");

                Instruction ins = Instruction.Get(uhChemexCodeAsByte);
                Console.WriteLine($"-{ins.OpCodeID}");
                Console.WriteLine($"-{ins.GetDescription()}");
            }
            else if (command.Length == 3 && OpCodeIDs.IsInternalCode(command))
            {
                Console.WriteLine($"\nDetails about {command}\n");

                Instruction ins = Instruction.Get(command);
                Console.WriteLine($"-{ins.OpCodeID}");
                Console.WriteLine($"-{ins.GetDescription()}");
            }
            else if (byte.TryParse(command, out byte num))
            {
                Instruction ins = Instruction.Get(num);
                Console.WriteLine($"\nDetails about {num}/{ChemexCharacters.ToChar(num)}/{ChemexConvertor.ToChemexCode(num)}\n");
                Console.WriteLine($"-{ins.OpCodeID}");
                Console.WriteLine($"-{ins.GetDescription()}");
            }
            else if (command.Length == 1 && char.IsLetter(command[1]))
            {
                char letter = command[0];
                byte thing = ChemexCharacters.ToByte(letter);
                Console.WriteLine($"\nDetails about {letter}/{thing}/{ChemexConvertor.ToChemexCode(thing)}\n");

                Instruction ins = Instruction.Get(thing);
                Console.WriteLine($"-{ins.OpCodeID}");
                Console.WriteLine($"-{ins.GetDescription()}\n");
            }
        }
    }
}
