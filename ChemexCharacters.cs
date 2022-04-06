using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMX
{
    public static class ChemexCharacters
    {
        private static readonly char[] Characters =
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            ' ', '.', ',', '!', ':', '(', ')'
        };

        public static void Init()
        {
            for (byte i = 0; i < Characters.Length; i++)
            {
                ToCharDict[i] = Characters[i];
                ToByteDict[Characters[i]] = i;
            }
        }

        public static char ToChar(byte value)
        {
            if (!ToCharDict.ContainsKey(value)) return '\n';
            return ToCharDict[value];
        }

        public static byte ToByte(char value)
        {
            if (!ToByteDict.ContainsKey(value)) return 0;
            return ToByteDict[value];
        }

        private static readonly Dictionary<byte, char> ToCharDict = new Dictionary<byte, char>();
        private static readonly Dictionary<char, byte> ToByteDict = new Dictionary<char, byte>();
    }
}
