using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LibRawNet.Native {
    /// <summary>
    /// This structure (actually, a bit field) describes the source of color data
    /// for each field of structure <see cref="libraw_colordata_t" />, which may be obtained from 
    /// different data sources.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct color_data_state_t {
        public uint bitdata;
    }
}
