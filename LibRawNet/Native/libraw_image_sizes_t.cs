using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace LibRaw.Native {
    /// <summary>Image Dimensions</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct libraw_image_sizes_t {
        public ushort raw_height;
        public ushort raw_width;
        public ushort height;
        public ushort width;
        public ushort top_margin;
        public ushort left_margin;
        public ushort bottom_margin;
        public ushort right_margin;
        public ushort iheight;
        public ushort iwidth;
        public double pixel_aspect;
        public int flip;
    }
}
