using System;
using System.Collections.Generic;

namespace LibRawNet.Native {
    [Flags]
    internal enum LibRaw_progress {
        LIBRAW_PROGRESS_START               = 0,
        LIBRAW_PROGRESS_OPEN                = 1,
        LIBRAW_PROGRESS_IDENTIFY            = 1<<1,
        LIBRAW_PROGRESS_SIZE_ADJUST         = 1<<2,
        LIBRAW_PROGRESS_LOAD_RAW            = 1<<3,
        LIBRAW_PROGRESS_REMOVE_ZEROES       = 1<<4,
        LIBRAW_PROGRESS_BAD_PIXELS          = 1<<5,
        LIBRAW_PROGRESS_DARK_FRAME          = 1<<6,
        LIBRAW_PROGRESS_FOVEON_INTERPOLATE  = 1<<7,
        LIBRAW_PROGRESS_SCALE_COLORS        = 1<<8,
        LIBRAW_PROGRESS_PRE_INTERPOLATE     = 1<<9,
        LIBRAW_PROGRESS_INTERPOLATE         = 1<<10,
        LIBRAW_PROGRESS_MIX_GREEN           = 1<<11,
        LIBRAW_PROGRESS_MEDIAN_FILTER       = 1<<12,
        LIBRAW_PROGRESS_HIGHLIGHTS          = 1<<13,
        LIBRAW_PROGRESS_FUJI_ROTATE         = 1<<14,
        LIBRAW_PROGRESS_FLIP                = 1<<15,
        LIBRAW_PROGRESS_APPLY_PROFILE       = 1<<16,
        LIBRAW_PROGRESS_CONVERT_RGB         = 1<<17,
        LIBRAW_PROGRESS_STRETCH             = 1<<18,
    /* reserved */
        LIBRAW_PROGRESS_STAGE19             = 1<<19,
        LIBRAW_PROGRESS_STAGE20             = 1<<20,
        LIBRAW_PROGRESS_STAGE21             = 1<<21,
        LIBRAW_PROGRESS_STAGE22             = 1<<22,
        LIBRAW_PROGRESS_STAGE23             = 1<<23,
        LIBRAW_PROGRESS_STAGE24             = 1<<24,
        LIBRAW_PROGRESS_STAGE25             = 1<<25,
        LIBRAW_PROGRESS_STAGE26             = 1<<26,
        LIBRAW_PROGRESS_STAGE27             = 1<<27,

        LIBRAW_PROGRESS_THUMB_LOAD          = 1<<28,
        LIBRAW_PROGRESS_TRESERVED1          = 1<<29,
        LIBRAW_PROGRESS_TRESERVED2          = 1<<30,
        LIBRAW_PROGRESS_TRESERVED3          = 1<<31
    }
}
