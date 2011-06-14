using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LibRawNet.Native {
    /// <summary>Image Dimensions</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct libraw_image_sizes_t {
        /// <summary>Full height of RAW image (including the frame) in pixels.</summary>
        public ushort raw_height;

        /// <summary>Full width of RAW image (including the frame) in pixels.</summary>
        public ushort raw_width;

        /// <summary>Height of visible ("meaningful") part of the image (without the frame).</summary> 
        public ushort height;

        /// <summary>Width of visible ("meaningful") part of the image (without the frame).</summary>
        public ushort width;

        /// <summary>
        /// Coordinate of the top left corner of the frame (the second corner is
        /// calculated from the full size of the image and size of its visible part).
        /// </summary>
        public ushort top_margin;

        /// <summary>
        /// Coordinate of the top left corner of the frame (the second corner is
        /// calculated from the full size of the image and size of its visible part).
        /// </summary>
        public ushort left_margin;
        
        /// <summary>
        /// Height of the output image (may differ from height for cameras that require
        /// image rotation or have non-square pixels).
        /// </summary>
        public ushort iheight;

        /// <summary>
        /// Width of the output image (may differ from width for cameras that require
        /// image rotation or have non-square pixels).
        /// </summary>
        public ushort iwidth;

        /// <summary>
        /// Pixel width/height ratio. If it is not unity, scaling of the image along 
        /// one of the axes is required during output.
        /// </summary>
        public double pixel_aspect;

        /// <summary>
        /// Image orientation (
        ///     0 if does not require rotation;
        ///     3 if requires 180-deg rotation;
        ///     5 if 90 deg counterclockwise,
        ///     6 if 90 deg clockwise
        /// ).
        /// </summary>
        public int flip;

        /// <summary> Width (in pixels) of right part of masked pixels area.</summary>
        public ushort right_margin;

        /// <summary> Width (in pixels) of bottom part of masked pixels area.</summary>
        public ushort bottom_margin;
    }
}
