using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace LibRaw.Native {
    [StructLayout(LayoutKind.Sequential)]
    internal struct libraw_thumbnail_t {
        public LibRaw_thumbnail_formats tformat;
        public ushort twidth;
        public ushort height;
        public uint tlength;
        public int tcolors;
        public IntPtr thumb;
    }
}
