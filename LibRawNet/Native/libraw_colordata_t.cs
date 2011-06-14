using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace LibRaw.Native {
    [StructLayout(LayoutKind.Sequential)]
    internal struct libraw_colordata_t {
        public color_data_state_t color_flags;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8 * 8)]
        public ushort[] white; //[8][8];

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4 * 3)]
        public float[] cam_xyz; //[4][3];

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] cam_mul;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] pre_mul;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 4)]
        public float[] cmatrix; //[3][4];

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 4)]
        public float[] rgb_cam; //[3][4];

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x4001)]
        public ushort[] curve; //[0x4001];

        public uint black;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public uint[] cblack;

        public uint maximum;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] channel_maximum;

        public ph1_t phase_one_data;
        public float flash_used;
        public float canon_ev;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] model2;

        public IntPtr profile;
        public uint profile_length;
    }
}
