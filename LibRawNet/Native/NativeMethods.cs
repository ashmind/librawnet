using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Runtime.InteropServices;

namespace LibRawNet.Native {
    [SuppressUnmanagedCodeSecurity]
    internal static class NativeMethods {
        [DllImport("libraw")]
        public static extern IntPtr libraw_init(uint flags);

        [DllImport("libraw")]
        public static extern int libraw_open_file(IntPtr data, string fileName);

        [DllImport("libraw")]
        public static extern int libraw_unpack(IntPtr data);

        [DllImport("libraw")]
        public static extern int libraw_close(IntPtr data);
    }
}
