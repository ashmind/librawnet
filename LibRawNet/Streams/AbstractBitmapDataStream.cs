using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace LibRawNet.Streams {
    internal abstract class AbstractBitmapDataStream : Stream {
        public abstract Size BitmapSize { get; }
        public abstract int BitsPerPixel { get; }
    }
}
