using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace LibRaw.Native {
    [StructLayout(LayoutKind.Explicit)]
    public struct color_data_state_t {
        uint curve_state        : 3;
        uint rgb_cam_state      : 3;
        uint cmatrix_state      : 3;
        uint pre_mul_state      : 3;
        uint cam_mul_state      : 3;
    }
}
