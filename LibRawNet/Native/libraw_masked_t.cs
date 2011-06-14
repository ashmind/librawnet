using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace LibRaw.Native {
    [StructLayout(LayoutKind.Sequential)]
    internal struct libraw_masked_t {
        public IntPtr buffer;
        public IntPtr tl;
        public IntPtr top;
        public IntPtr tr;
ushort *left;
Pointer to pixel data of left frame side. (left_margin*height) pixels.
ushort *right;
Right side of frame. (right_margin*height) pixels.
ushort *bl;
Bottom left corner of frame. (bottom_margin*left_margin) pixels.
ushort *bottom;
Bottom side of frame. Pixel count is (bottom_margin*width).
ushort *br;
Bottom right corner with (bottom_margin*right_margin) pixels.
ushort (*ph1_black)[2];
    }
}
