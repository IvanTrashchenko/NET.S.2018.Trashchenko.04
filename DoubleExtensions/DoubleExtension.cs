using System.Runtime.InteropServices;
using System.Text;

namespace DoubleExtensions
{
    /// <summary>
    /// Class of DoubleToBinaryString method.
    /// </summary>
    public static class DoubleExtension
    {
        #region Constants

        /// <summary>
        /// Amount of bits in byte.
        /// </summary>
        private const int BitsInByte = 8;

        #endregion

        #region Converting method

        /// <summary>
        /// Method of finding string binary representation of a real number.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Binary representation of number of type <see cref="string"/>. </returns>
        public static string DoubleToBinaryString(this double number)
        {
            long numberLong = new DoubleToLongStruct(number).Long64bits;

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < BitsInByte * 8; i++)
            {
                result.Insert(0, (numberLong & 1) == 1 ? "1" : "0");

                numberLong >>= 1;
            }

            return result.ToString();
        }

        #endregion

        #region DoubleToLongStruct 

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongStruct
        {
            [FieldOffset(0)]
            private readonly long long64bits;

            [FieldOffset(0)]
            private double double64bits;

            public DoubleToLongStruct(double number) : this()
            {
                double64bits = number;
            }

            public long Long64bits
            {
                get => this.long64bits;
            }
        }

        #endregion       
    }
}
