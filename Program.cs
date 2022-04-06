using System;

namespace CMX
{
    public class Program
    {
        public const string VERSION = "0.1";

        static void Main(string[] args)
        {
            ChemexCharacters.Init();
            CMXRunner.Run();

            Console.WriteLine("Press enter to quit...");
            Console.ReadLine();
        }
    }
}
