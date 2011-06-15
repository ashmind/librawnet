using System;
using System.Collections.Generic;
using System.Security;
using System.Runtime.InteropServices;

namespace LibRawNet.Native {
    [SuppressUnmanagedCodeSecurity]
    internal static class NativeMethods {
        [DllImport("libraw")]
        public static extern IntPtr libraw_init(LibRaw_constructor_flags flags);

        [DllImport("libraw")]
        public static extern int libraw_open_file(IntPtr data, string fileName);

        [DllImport("libraw")]
        public static extern int libraw_unpack(IntPtr data);

        [DllImport("libraw")]
        public static extern int libraw_close(IntPtr data);

        [DllImport("libraw")]
        public static extern int libraw_dcraw_process(IntPtr lr);

        [DllImport("libraw")]
        public static extern IntPtr libraw_dcraw_make_mem_image(IntPtr data, out int errc);
    }
}
