using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMX
{
    public static class Data
    {
        private const int DATA_SIZE = byte.MaxValue;

        public static readonly byte[] data = new byte[DATA_SIZE];

        public static uint StackPointer;

        /// <summary>
        /// Gets the data at <paramref name="index"/>
        /// </summary>
        public static byte Get(uint index)
        {
            if (index > DATA_SIZE)
            {
                Console.WriteLine($"Tried to get data with index {index}. Data range is 0-{DATA_SIZE}");
                Math.Clamp(index, 0, DATA_SIZE);
            }

            return data[index];
        }


        /// <summary>
        /// Gets a reference to the data at <paramref name="index"/>
        /// </summary>
        public static ref byte GetRef(uint index)
        {
            if (index > DATA_SIZE)
            {
                Console.WriteLine($"Tried to get data with index {index}. Data range is 0-{DATA_SIZE}");
                Math.Clamp(index, 0, DATA_SIZE);
            }

            return ref data[index];
        }


        /// <summary>
        /// Gets the data at the current stack pointer
        /// </summary>
        public static byte GetP()
        {
            return Get(StackPointer);
        }


        /// <summary>
        /// Gets the data at the current stack pointer + <paramref name="offset"/>
        /// </summary>
        public static byte GetP(int offset)
        {
            return Get((uint)(StackPointer + offset));
        }


        /// <summary>
        /// Gets a reference to the data at the current stack pointer
        /// </summary>
        public static ref byte GetRefP()
        {
            return ref GetRef(StackPointer);
        }


        /// <summary>
        /// Gets a reference to the data at the current stack pointer + <paramref name="offset"/>
        /// </summary>
        public static ref byte GetRefP(int offset)
        {
            return ref GetRef((uint)(StackPointer + offset));
        }


        /// <summary>
        /// Sets the data at <paramref name="index"/> to <paramref name="value"/>
        /// </summary>
        public static void Set(uint index, byte value)
        {
            if (index > DATA_SIZE)
            {
                Console.WriteLine($"Tried to get data with index {index}. Data range is 0-{DATA_SIZE}");
                Math.Clamp(index, 0, DATA_SIZE);
            }

            data[index] = value;
        }


        /// <summary>
        /// Sets the data at the current stack pointer to <paramref name="value"/>
        /// </summary>
        public static void SetP(byte value)
        {
            Set(StackPointer, value);
        }
    }
}
