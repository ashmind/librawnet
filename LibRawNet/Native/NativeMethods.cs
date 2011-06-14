using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;

namespace LibRaw.Native {
    [SuppressUnmanagedCodeSecurity]
    internal static class NativeMethods {
        [DllImport("libraw")]
        IntPtr libraw_init(uint flags);

        [DllImport("libraw")]
        public extern int libraw_open_file(IntPtr data, string fileName);

        [DllImport("libraw")]
        public extern int libraw_unpack(IntPtr data);

        [DllImport("libraw")]
        public extern int libraw_close(IntPtr data);
    }
}
