using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace LibRawNet.Native {
    /// <summary>Main Parameters of the Image</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct libraw_iparams_t {
        /// <summary>Camera manufacturer.</summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string make;

        /// <summary>Camera model.</summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string model;

        /// <summary>Number of RAW images in file (0 means that the file has not been recognized).</summary>
        public uint raw_count;

        /// <summary>DNG version (for the DNG format).</summary>
        public uint dng_version;

        /// <summary>Number of colors in the file.</summary>
        public int colors;

        /// <summary>
        /// Bit mask describing the order of color pixels in the  matrix (0 for full-color images).
        /// 32 bits of this field describe 16 pixels (8 rows with two pixels in each, from left to right
        /// and from top to bottom). Each two bits have values 0 to 3, which correspond to four possible colors.
        /// Convenient work with this field is ensured by the COLOR(row,column) function, which returns
        /// the number of the active color for a given pixel.
        /// </summary>
        public uint filters;

        /// <summary>Description of colors numbered from 0 to 3 (RGBG,RGBE,GMCY, or GBTG).</summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string cdesc;
    }
}
