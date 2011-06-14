using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace LibRaw.Native {
    [StructLayout(LayoutKind.Sequential)]
    internal struct libraw_imgother_t {
        public float iso_speed;
        public float shutter;
        public float aperture;
        public float focal_len;
        public UIntPtr timestamp;
        public uint shot_order;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public uint[] gpsdata;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public char[] desc;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public char[] artist;
    }
}
