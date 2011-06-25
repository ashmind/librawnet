using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

using LibRawNet.Internal;
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

        public Stream ToBitmapStream() {
            this.EnsureProcessed();
            var error = 0;
            
            // temporary gamma fix
            var imagePtr = NativeMethods.libraw_dcraw_make_mem_image(this.dataPtr, out error);
            NativeMethods.libraw_dcraw_clear_mem(imagePtr);
            // end of fix

            return new BmpBitmapStream(new LibRawBitmapDataStream(GetStructure<libraw_data_t>(this.dataPtr)));
        }

        public Bitmap ToBitmap() {
            using (var stream = this.ToBitmapStream()) {
                return new Bitmap(stream);
            }
        }

        private void EnsureProcessed() {
            if (this.processed)
                return;

            ProcessResult(NativeMethods.libraw_unpack(this.dataPtr));
            this.ChangeData(data => {
                data.@params.use_camera_wb = 1;
                return data;
            });

            ProcessResult(NativeMethods.libraw_dcraw_process(this.dataPtr));
            this.processed = true;
        }

        private void ChangeData(Func<libraw_data_t, libraw_data_t> change) {
            var data = GetStructure<libraw_data_t>(this.dataPtr);
            data = change(data);
            Marshal.StructureToPtr(data, this.dataPtr, true);
        }

        private static T GetStructure<T>(IntPtr ptr)
            where T : struct
        {
            return (T)Marshal.PtrToStructure(ptr, typeof (T));
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
