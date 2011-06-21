using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace LibRawNet.Internal {
    internal class UnmanagedBgrBitmapDataStream : AbstractBitmapDataStream {
        private enum ColorPart {
            Blue,
            Green,
            Red
        }

        private readonly IntPtr dataPtr;
        private readonly Size bitmapSize;
        private readonly int bitsPerPixel;
        private readonly Action dispose;

        private int row;
        private int column;
        
        private bool flushSaved;
        private byte? savedBlue;
        private byte? savedGreen;

        public UnmanagedBgrBitmapDataStream(IntPtr dataPtr, Size bitmapSize, int bitsPerPixel, Action dispose) {
            this.dataPtr = dataPtr;
            this.bitmapSize = bitmapSize;
            this.bitsPerPixel = bitsPerPixel;
            this.dispose = dispose;
        }

        public override Size BitmapSize {
            get { return this.bitmapSize; }
        }

        public override int BitsPerPixel {
            get { return this.bitsPerPixel; }
        }

        public override bool CanRead {
            get { return true; }
        }

        public override long Length {
            get { return this.BitmapSize.Width * this.BitmapSize.Height * (this.BitsPerPixel / 8); }
        }

        public override long Position {
            get { return (this.row * this.RowSize) + this.column; }
            set { throw new NotSupportedException(); }
        }

        private int RowSize {
            get { return this.BitmapSize.Width * 3; }
        }

        private int DataOffset {
            get { return ((this.BitmapSize.Height - this.row - 1) * this.RowSize) + this.column; }
        }

        public override int Read(byte[] buffer, int offset, int count) {
            if (this.BitsPerPixel / 3 != 8)
                throw new NotImplementedException("Support for " + this.BitsPerPixel + " bits per pixel is not yet implemented.");

            var availableCount = (int)Math.Min(count, this.Length - this.Position);
            var index = 0;
            while (index < availableCount) {
                if (this.flushSaved) {
                    if (this.savedGreen != null) {
                        buffer[offset + index] = this.savedGreen.Value;
                        index += 1;
                        this.savedGreen = null;
                        continue;
                    }

                    if (this.savedBlue != null) {
                        buffer[offset + index] = this.savedBlue.Value;
                        index += 1;
                        this.savedBlue = null;
                    }

                    this.flushSaved = false;
                    continue;
                }

                var colorPartValue = Marshal.ReadByte(this.dataPtr, this.DataOffset);
                var colorPartKind = (ColorPart)(this.Position % 3);

                if (colorPartKind == ColorPart.Red) {
                    buffer[offset + index] = colorPartValue;
                    index += 1;
                    this.flushSaved = true;
                }
                else if (colorPartKind == ColorPart.Green) {
                    this.savedGreen = colorPartValue;
                }
                else {
                    this.savedBlue = colorPartValue;
                }
                this.column += 1;
                if (this.column == this.RowSize) {
                    this.column = 0;
                    this.row += 1;
                }
            }

            return availableCount;
        }

        protected override void Dispose(bool disposing) {
            try {
                this.dispose();
            }
            finally {
                base.Dispose(disposing);
            }
        }

        #region Unsupported

        public override bool CanSeek {
            get { return false; }
        }

        public override bool CanWrite {
            get { return false; }
        }

        public override void Flush() {
            throw new NotSupportedException();
        }

        public override long Seek(long offset, System.IO.SeekOrigin origin) {
            throw new NotSupportedException();
        }

        public override void SetLength(long value) {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count) {
            throw new NotSupportedException();
        }

        #endregion
    }
}
