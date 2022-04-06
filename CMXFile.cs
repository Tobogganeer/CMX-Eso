using System;
using System.Collections.Generic;
using System.IO;

namespace CMX
{
    public static class CMXFile
    {
        public static CMXFileType GetExtension(string fileName)
        {
            if (fileName.EndsWith(".cmx")) return CMXFileType.cmx;
            if (fileName.EndsWith(".cmi")) return CMXFileType.cmi;
            if (fileName.EndsWith(".cmb")) return CMXFileType.cmb;
            return CMXFileType.None;
        }

        public static CMXFileType GetFileType(string fileName, CMXFileType extension)
        {
            if (extension != CMXFileType.None && File.Exists(Path.Combine(Directory.GetCurrentDirectory(), fileName))) return extension;

            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), fileName + ".cmx"))) return CMXFileType.cmx;
            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), fileName + ".cmi"))) return CMXFileType.cmi;
            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), fileName + ".cmb"))) return CMXFileType.cmb;
            return CMXFileType.None;
        }

        public static bool LoadInstructions(string fileName)
        {
            CMXFileType extension = GetExtension(fileName);

            if (extension == CMXFileType.None)
                Console.WriteLine($"Searching for {fileName}.cmx/cmi/cmb ...");
            else
                Console.WriteLine($"Searching for {fileName} ...");

            CMXFileType type = GetFileType(fileName, extension);

            if (extension == CMXFileType.None)
                fileName += "." + type.ToString();

            string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);


            if (type == CMXFileType.cmx)
            {
                Code.LoadChemexCodes(File.ReadAllText(path));
                Console.WriteLine("Found " + fileName);
                return true;
            }
            else if (type == CMXFileType.cmi)
            {
                Code.LoadInternalCodes(File.ReadAllText(path));
                Console.WriteLine("Found " + fileName);
                return true;
            }
            else if (type == CMXFileType.cmb)
            {
                Code.LoadOpCodes(File.ReadAllBytes(path));
                Console.WriteLine("Found " + fileName);
                return true;
            }
            else return false;
        }
    }

    public enum CMXFileType
    {
        None,
        cmx,
        cmi,
        cmb
    }
}
