using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMX
{
    public static class ByteExtensions
    {
        public static byte Add(this byte l, byte r)
        {
            return (byte)((l + r) % 256);
        }

        public static byte Sub(this byte l, byte r)
        {
            int result = l - r;
            while (result < 0)
                result += 256;

            return (byte)result;
        }

        public static byte Mul(this byte l, byte r)
        {
            return (byte)((l * r) % 256);
        }

        public static byte Div(this byte l, byte r)
        {
            if (r == 0) return 0;

            return (byte)MathF.Round(l / (float)r);
        }
    }
}
