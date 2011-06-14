using System.Runtime.InteropServices;

namespace LibRawNet.Native {
    /// <summary>Not a libraw type, helper for multidimensional array.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct pixel_data {
        public ushort x1;
        public ushort x2;
        public ushort x3;
        public ushort x4;
    }
}