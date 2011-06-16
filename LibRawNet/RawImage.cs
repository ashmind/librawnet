using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

using LibRawNet.Native;

namespace LibRawNet {
    internal delegate TResult Func<in T, out TResult>(T arg1);

    public class RawImage : IDisposable {
        private static readonly IDictionary<int, PixelFormat> PixelFormats = new Dictionary<int, PixelFormat> {
            { 24, PixelFormat.Format24bppRgb },
            { 48, PixelFormat.Format48bppRgb }
        };

        private static readonly IDictionary<LibRaw_errors, Func<Exception, Exception>> ErrorWrappers = new Dictionary<LibRaw_errors, Func<Exception, Exception>> {
            { LibRaw_errors.LIBRAW_OUT_OF_ORDER_CALL, ex => new InvalidOperationException("This call was not expected at this point.", ex) }
        };

        private bool processed;
        private readonly IntPtr dataPtr;

        private RawImage(IntPtr dataPtr) {
            this.dataPtr = dataPtr;
        }

        public static RawImage FromFile(string fileName) {
            var dataPtr = NativeMethods.libraw_init(
                LibRaw_constructor_flags.LIBRAW_OPIONS_NO_DATAERR_CALLBACK | LibRaw_constructor_flags.LIBRAW_OPIONS_NO_MEMERR_CALLBACK
            );
            if (dataPtr == IntPtr.Zero)
                throw new LibRawNativeException("libraw_init returned NULL pointer.");

            ProcessResult(
                NativeMethods.libraw_open_file(dataPtr, fileName)
            );
            return new RawImage(dataPtr);
        }

        private static void ProcessResult(int result) {
            if (result == 0)
                return;

            var error = (LibRaw_errors)result;
            var ex = (Exception)new LibRawNativeException("Operation failed with error code " + error + ".");
            if (ErrorWrappers.ContainsKey(error))
                ex = ErrorWrappers[error].Invoke(ex);

            throw ex;
        }

        public Bitmap ToBitmap() {
            if (!this.processed) {
                ProcessResult(NativeMethods.libraw_unpack(this.dataPtr));
                ProcessResult(NativeMethods.libraw_dcraw_process(this.dataPtr));
                this.processed = true;
            }

            var error = 0;
            var imagePtr = NativeMethods.libraw_dcraw_make_mem_image(this.dataPtr, out error);
            ProcessResult(error);

            var imageData = (libraw_processed_image_t)Marshal.PtrToStructure(imagePtr, typeof(libraw_processed_image_t));
            var bpp = imageData.colors * imageData.bits;
            var bytesPerPixel = (bpp + 7) / 8;

            return new Bitmap(
                imageData.width, imageData.height,
                 4 * ((imageData.width * bytesPerPixel + 3) / 4),
                PixelFormats[bpp], imageData.data(imagePtr)
            );
        }

        public void Dispose() {
            this.Dispose(true);
        }

        private void Dispose(bool disposing) {
            if (disposing)
                GC.SuppressFinalize(this);

            NativeMethods.libraw_close(this.dataPtr);
        }

        ~RawImage() {
            this.Dispose(false);
        }
    }
}
