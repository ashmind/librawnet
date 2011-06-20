using System;
using System.Collections.Generic;
using System.IO;

namespace LibRawNet.Internal {
    internal class BmpBitmapStream : Stream {
        private readonly AbstractBitmapDataStream dataStream;
        private readonly byte[] header;
        private int? positionInHeader;

        public BmpBitmapStream(AbstractBitmapDataStream dataStream) {
            this.dataStream = dataStream;
            this.header = GetHeader();
            this.positionInHeader = 0;
        }

        private byte[] GetHeader() {
            const int HeaderSize = 0x36;

            var headerStream = new MemoryStream();
            var binaryWriter = new BinaryWriter(headerStream);

            // "BM" Magic number (unsigned integer 66, 77)
            binaryWriter.Write((byte)0x42);
            binaryWriter.Write((byte)0x4D);

            // Size of the BMP file
            binaryWriter.Write(HeaderSize + (int)this.dataStream.Length);

            // Application specific
            binaryWriter.Write(0);

            // Offset where the Pixel Array (bitmap data) can be found
            binaryWriter.Write(HeaderSize);

            // Number of bytes in the DIB header (from this point)
            binaryWriter.Write(40);

            // Size of the bitmap in pixels
            binaryWriter.Write(this.dataStream.BitmapSize.Width);
            binaryWriter.Write(this.dataStream.BitmapSize.Height);

            // Number of color planes being used
            binaryWriter.Write((short)1);

            // Number of bits per pixel
            binaryWriter.Write((short)this.dataStream.BitsPerPixel);

            // BI_RGB, no Pixel Array compression used
            binaryWriter.Write(0);

            // Size of the raw data in the Pixel Array (including padding)
            binaryWriter.Write(0);

            // Resolution of the image
            binaryWriter.Write(3780); // no idea what does it mean for now
            binaryWriter.Write(3780);

            // Number of colors in the palette
            binaryWriter.Write(0);

            // 0 means all colors are important
            binaryWriter.Write(0);

            return headerStream.ToArray();
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
            get { return this.header.Length + this.dataStream.Length; }
        }

        public override long Position {
            get {
                if (this.positionInHeader != null)
                    return (int)this.positionInHeader;

                return this.header.Length + this.dataStream.Position;
            }
            set { throw new NotSupportedException(); }
        }

        public override int Read(byte[] buffer, int offset, int count) {
            var countWithinHeader = 0;
            if (this.positionInHeader != null) {
                countWithinHeader = count;
                if (Position + count > this.header.Length)
                    countWithinHeader = this.header.Length - offset;

                Array.Copy(this.header, this.Position, buffer, offset, countWithinHeader);
                this.positionInHeader += countWithinHeader;
                if (this.positionInHeader >= this.header.Length)
                    this.positionInHeader = null;

                if (countWithinHeader == count)
                    return countWithinHeader;

                offset += countWithinHeader;
                count -= countWithinHeader;
            }

            return countWithinHeader + this.dataStream.Read(buffer, offset, count);
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
