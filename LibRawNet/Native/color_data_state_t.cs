using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace LibRawNet.Native {
    /// <summary>
    /// This structure (actually, a bit field) describes the source of color data
    /// for each field of structure <see cref="libraw_colordata_t" />, which may be obtained from 
    /// different data sources.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 5 * 3)]
    public struct color_data_state_t {
        [FieldOffset(0 * 3)]
        public uint curve_state;

        [FieldOffset(1 * 3)]
        public uint rgb_cam_state;

        [FieldOffset(2 * 3)]
        public uint cmatrix_state;

        [FieldOffset(3 * 3)]
        public uint pre_mul_state;

        [FieldOffset(4 * 3)]
        public uint cam_mul_state;
    }
}
