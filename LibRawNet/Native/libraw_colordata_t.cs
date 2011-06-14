using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace LibRawNet.Native {
    [StructLayout(LayoutKind.Sequential)]
    internal struct libraw_colordata_t {
        /// <summary> Data structure describing the sources of color data. </summary>
        public color_data_state_t color_flags;

        /// <summary>
        /// Block of white pixels extracted from files CIFF/CRW.
        /// Not extracted for other formats. Used to calculate white balance coefficients.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8 * 8)]
        public ushort[] white; //[8][8];

        /// <summary>
        /// Camera RGB - XYZ conversion matrix. This matrix is constant (different for 
        /// different models). Last row is zero for RGB cameras and non-zero for different
        /// color models (CMYG and so on).
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4 * 3)]
        public float[] cam_xyz; //[4][3];

        /// <summary>
        /// White balance coefficients (as shot). Either read from file or calculated.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] cam_mul;

        /// <summary>
        /// White balance coefficients for daylight (daylight balance). Either read from file,
        /// or calculated on the basis of file data, or taken from hardcoded constants.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] pre_mul;

        /// <summary>
        /// White balance matrix. Read from file for some cameras, calculated for others.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 4)]
        public float[] cmatrix; //[3][4];

        /// <summary>
        /// Another white balance matrix, read from file for Leaf and Kodak cameras.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 4)]
        public float[] rgb_cam; //[3][4];

        /// <summary>
        /// Camera tone curve, read from file for Nikon, Sony and some other cameras.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x4001)]
        public ushort[] curve; //[0x4001];

        /// <summary>
        /// Black level. Depending on the camera, it may be zero (this means that black
        /// has been subtracted at the unpacking stage or by the camera itself), 
        /// calculated at the unpacking stage, read from the RAW file, or hardcoded.
        /// </summary>
        public uint black;

        /// <summary>
        /// Per-channel black level. Items 0-3 are black pixels values (averaged), items 4-7 are per-channel counts.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public uint[] cblack;

        /// <summary>
        /// Maximum pixel value. Calculated from the data for most cameras, hardcoded for others. This value may be 
        /// changed on postprocessing stage (when black subtraction performed) and by automated maximum adjustment 
        /// (this adjustment performed if params.adjust_maximum_thr is set to nonzero).
        /// </summary>
        public uint maximum;

        /// <summary>
        /// Per channel maximum pixel value. Calculated from RAW data on unpack stage.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] channel_maximum;

        /// <summary>
        /// Color data block that is read for Phase One cameras.
        /// </summary>
        public ph1_t phase_one_data;

        /// <summary> Field used for white balance calculations (for some P&S Canon cameras). </summary>
        public float flash_used;

        /// <summary> Field used for white balance calculations (for some P&S Canon cameras). </summary>
        public float canon_ev;

        /// <summary> Firmware revision (for some cameras). </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] model2;

        /// <summary> Pointer to the retrieved ICC profile (if it is present in the RAW file). </summary>
        public IntPtr profile;

        /// <summary> Length of ICC profile in bytes. </summary>
        public uint profile_length;
    }
}
