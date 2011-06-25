using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using LibRawNet.Native;

namespace LibRawNet.Internal {
    internal class LibRawBitmapDataStream : AbstractBitmapDataStream {
        private readonly libraw_data_t data;
        private readonly int imageDataSize;
        private readonly int rowPadding;

        private int currentRow;
        private int currentColumn;
        private int currentColorIndex;
        private int currentRowPadding;
        private readonly Size bitmapSize;
        
        public LibRawBitmapDataStream(libraw_data_t data) {
            this.data = data;
            this.bitmapSize = (this.data.sizes.flip & 4) != 4 
                            ? new Size(data.sizes.width, data.sizes.height)
                            : new Size(data.sizes.height, data.sizes.width);

            var unpaddedRowSize = (this.bitmapSize.Width * this.BitsPerPixel / 8);
            this.rowPadding = 4 - (unpaddedRowSize % 4);
            if (this.rowPadding == 4)
                this.rowPadding = 0;

            this.imageDataSize = data.sizes.height * this.RowSize;
        }

        public override int BitsPerPixel {
            get { return data.@params.output_bps * data.idata.colors; }
        }

        public override Size BitmapSize {
            get { return this.bitmapSize; }
        }

        public override bool CanRead {
            get { return true; }
        }

        public override bool CanSeek {
            get { return false; }
        }

        public override bool CanWrite {
            get { return false; }
        }

        public override void Flush() {
            throw new NotSupportedException();
        }

        public override long Length {
            get { return this.imageDataSize; }
        }

        public override long Position {
            get { throw new NotImplementedException(); }
            set { throw new NotSupportedException(); }
        }

        private int RowSize {
            get { return (this.bitmapSize.Width * this.BitsPerPixel / 8) + this.rowPadding; }
        }

        public override int Read(byte[] buffer, int offset, int count) {
            var colorCount = this.data.idata.colors;
            var width = this.bitmapSize.Width;

            var bits = data.@params.output_bps;
            if (bits != 8 || colorCount != 3)
                throw new NotImplementedException();
            
            var image = this.data.image;
            var bufferSubOffset = 0;
            for (; this.currentRow < this.bitmapSize.Height; this.currentRow += 1) {
                var bmpBitmapRow = this.bitmapSize.Height - this.currentRow - 1; // BMPs are upside down

                for (; this.currentColumn < width; this.currentColumn += 1) {
                    for (; this.currentColorIndex < colorCount; this.currentColorIndex += 1) {
                        var bgrColorIndex = colorCount - 1 - this.currentColorIndex;
                        var bitmapOffset = this.GetSourceOffset(bmpBitmapRow, this.currentColumn);

                        var @color = (ushort)Marshal.ReadInt16(image, (bitmapOffset * 4 + bgrColorIndex) * sizeof(short));
                        buffer[offset + bufferSubOffset] = (byte)(this.data.color.curve[@color] >> 8);

                        bufferSubOffset += 1;
                        if (bufferSubOffset == count) {
                            this.currentColorIndex += 1; // loop will not increase it because we return
                            return count;
                        }
                    }

                    this.currentColorIndex = 0;
                }

                for (; this.currentRowPadding < this.rowPadding; this.currentRowPadding += 1) {
                    bufferSubOffset += 1;
                    if (bufferSubOffset == count) {
                        this.currentRowPadding += 1; // loop will not increase it because we return
                        return count;
                    }
                }

                this.currentColumn = 0;
                this.currentRowPadding = 0;
            }

            return bufferSubOffset;
        }

        private int GetSourceOffset(int row, int column) {
            var size = this.data.sizes;
            var flip = this.data.sizes.flip;

            if ((flip & 4) == 4) {
                var swap = row;
                row = column;
                column = swap;
            }

            if ((flip & 2) == 2)
                row = size.height - 1 - row;

            if ((flip & 1) == 1)
                column = size.width - 1 - column;

            return row * size.width + column;
        }

        public override long Seek(long offset, SeekOrigin origin) {
            throw new NotSupportedException();
        }

        public override void SetLength(long value) {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count) {
            throw new NotSupportedException();
        }
    }
}
