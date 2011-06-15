using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LibRawNet.Native {
    [StructLayout(LayoutKind.Sequential)]
    internal struct libraw_imgother_t {
        /// <summary> ISO sensitivity. </summary>
        public float iso_speed;

        /// <summary> Shutter speed. </summary>
        public float shutter;

        /// <summary> Aperture. </summary>
        public float aperture;

        /// <summary> Focal length. </summary>
        public float focal_len;

        /// <summary> Date of shooting. </summary>
        public IntPtr timestamp;

        /// <summary> Serial number of image. </summary>
        public uint shot_order;

        /// <summary> GPS data. </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public uint[] gpsdata;

        /// <summary> Image description. </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        public string desc;

        /// <summary> Author of image. </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string artist;
    }
}
