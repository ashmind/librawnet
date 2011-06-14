using System;
using System.Collections.Generic;

namespace LibRawNet.Native {
    internal enum LibRaw_errors {
        LIBRAW_SUCCESS = 0,
        LIBRAW_UNSPECIFIED_ERROR = -1,
        LIBRAW_FILE_UNSUPPORTED = -2,
        LIBRAW_REQUEST_FOR_NONEXISTENT_IMAGE = -3,
        LIBRAW_OUT_OF_ORDER_CALL = -4,
        LIBRAW_NO_THUMBNAIL = -5,
        LIBRAW_UNSUPPORTED_THUMBNAIL = -6,
        LIBRAW_CANNOT_ADDMASK = -7,
        LIBRAW_UNSUFFICIENT_MEMORY = -100007,
        LIBRAW_DATA_ERROR = -100008,
        LIBRAW_IO_ERROR = -100009,
        LIBRAW_CANCELLED_BY_CALLBACK = -100010,
        LIBRAW_BAD_CROP = -100011
    }
}
