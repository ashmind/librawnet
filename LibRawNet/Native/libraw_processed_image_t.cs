using System;
using System.Runtime.InteropServices;

namespace LibRawNet.Native {
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct libraw_processed_image_t {
        public LibRaw_image_formats type;
        public ushort height;
        public ushort width;
        public ushort colors;
        public ushort bits;
        public uint data_size;
        public IntPtr data;
    }
}