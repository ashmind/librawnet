using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace LibRawNet.Native {
    /// <summary>
    /// Structure <see cref="libraw_thumbnail_t" /> describes all parameters associated with the preview saved in the RAW file.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct libraw_thumbnail_t {
        /// <summary> Thumbnail data format. One of the values among enum <see cref="LibRaw_thumbnail_formats" />. </summary>
        public LibRaw_thumbnail_formats tformat;

        /// <summary> Width of the preview image in pixels. </summary>
        public ushort twidth;

        /// <summary> Height of the preview image in pixels. </summary>
        public ushort height;

        /// <summary> Thumbnail length in bytes. </summary>
        public uint tlength;

        /// <summary> Number of colors in the preview. </summary>
        public int tcolors;

        /// <summary> Pointer to thumbnail, extracted from the data file. </summary>
        public IntPtr thumb;
    }
}
