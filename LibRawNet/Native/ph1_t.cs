﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LibRawNet.Native {
    [StructLayout(LayoutKind.Sequential)]
    internal struct ph1_t {
        public int format;
        public int key_off;
        public int t_black;
        public int black_off;
        public int split_col;
        public int tag_21a;
        public float tag_210;
    }
}
