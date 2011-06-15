using System;

namespace LibRawNet.Native {
    [Flags]
    internal enum LibRaw_constructor_flags {
        LIBRAW_OPTIONS_NONE = 0,
        LIBRAW_OPIONS_NO_MEMERR_CALLBACK = 1,
        LIBRAW_OPIONS_NO_DATAERR_CALLBACK = 1 << 1
    }
}