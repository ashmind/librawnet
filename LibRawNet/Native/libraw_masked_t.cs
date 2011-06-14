using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace LibRawNet.Native {
    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_masked_t {
        public IntPtr buffer;
        public IntPtr tl;
        public IntPtr top;
        public IntPtr tr;
        public IntPtr left;
        public IntPtr right;
        public IntPtr bl;
        public IntPtr bottom;
        public IntPtr br;
        public IntPtr ph1_black;
    }
}
