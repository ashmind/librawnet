using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace LibRaw.Native {
    /// <summary>Main Data Structure of LibRaw</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct libraw_data_t {
        /// <summary>This field records the past phases of image processing.</summary>
        public uint progress_flags;

        /// <summary>This field records suspicious situations (warnings) that have emerged during image processing.</summary>
        public uint progress_flags_2;

        /// <summary>The structure describes the main image parameters retrieved from the RAW file.</summary>
        public libraw_iparams_t idata;

        /// <summary>The structure describes the geometrical parameters of the image.</summary>
        public libraw_image_sizes_t sizes;

        /// <summary>The structure contains color data retrieved from the file.</summary>
        public libraw_colordata_t color;

        ///// <summary>Data structure for information purposes: it contains the image parameters that have been extracted from the file but are not needed in further file processing.</summary>
        public libraw_imgother_t other;

        ///// <summary>Data structure containing information on the preview and the preview data themselves. All fields of this structure but thumbnail itself are filled when open_file() is called. Thumbnail readed by unpack_thumb() call.</summary>
        public libraw_thumbnail_t thumbnail;

        ///// <summary>Structure containing pixel data for black (masked) border pixels. It is filled when unpack() is called.</summary>
        public libraw_masked_t masked_pixels;
            
        ///// <summary>The memory area that contains the image pixels per se. It is filled when unpack() is called.</summary>
        //public ushort (*image)[4];

        ///// <summary>Data structure intended for management of image postprocessing (using the dcraw emulator).</summary>
        //public libraw_output_params_t @params;
    }
}
