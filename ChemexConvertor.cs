using System;
using System.Collections.Generic;

namespace CMX
{
    public static class ChemexConvertor
    {
        public static string ToChemexCode(byte opCode)
        {
            string lower = "xemehc";
            char[] chemex = new char[6];

            for (byte i = 0; i < 6; i++)
            {
                chemex[i] = IsBitSet(opCode, i) ? char.ToUpper(lower[i]) : lower[i];
            }

            Array.Reverse(chemex);

            return new string(chemex);
        }

        private static bool IsBitSet(byte b, byte pos)
        {
            return (b & (1 << pos)) != 0;
        }


        public static byte ToNumber(string chemexCode)
        {
            if (!IsChemexCode(chemexCode))
                throw new ArgumentException("The passed string was not a chemex code");

            //for (int i = 0; i < chars.Length; i++)
            //{
            //    yourvalue |= (chars[i] - '0') << i;
            //}

            byte num = 0;

            char[] chars = chemexCode.ToCharArray();

            Array.Reverse(chars);

            chemexCode = new string(chars);

            for (byte i = 0; i < 6; i++)
            {
                num |= (byte)((char.IsUpper(chemexCode[i]) ? 1 : 0) << i);
            }

            return num;
        }

        public static bool IsChemexCode(string str)
        {
            if (str.Length != 6) return false;
            if (str.ToLower() != "chemex") return false;

            return true;
        }
    }
}
