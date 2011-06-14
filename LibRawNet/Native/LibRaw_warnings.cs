using System;
using System.Collections.Generic;

namespace LibRawNet.Native {
    [Flags]
    internal enum LibRaw_warnings {
        LIBRAW_WARN_NONE = 0,
        LIBRAW_WARN_FOVEON_NOMATRIX = 1,
        LIBRAW_WARN_FOVEON_INVALIDWB = 1 << 1,
        LIBRAW_WARN_BAD_CAMERA_WB = 1 << 2,
        LIBRAW_WARN_NO_METADATA = 1 << 3,
        LIBRAW_WARN_NO_JPEGLIB = 1 << 4,
        LIBRAW_WARN_NO_EMBEDDED_PROFILE = 1 << 5,
        LIBRAW_WARN_NO_INPUT_PROFILE = 1 << 6,
        LIBRAW_WARN_BAD_OUTPUT_PROFILE = 1 << 7,
        LIBRAW_WARN_NO_BADPIXELMAP = 1 << 8,
        LIBRAW_WARN_BAD_DARKFRAME_FILE = 1 << 9,
        LIBRAW_WARN_BAD_DARKFRAME_DIM = 1 << 10
    }
}
