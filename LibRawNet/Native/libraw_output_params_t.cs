using System.Runtime.InteropServices;

namespace LibRawNet.Native {
    [StructLayout(LayoutKind.Sequential)]
    public struct libraw_output_params_t {
        /// unsigned int[4]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
        public uint[] greybox;

        /// unsigned int[4]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
        public uint[] cropbox;

        /// double[4]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.R8)]
        public double[] aber;

        /// double[6]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.R8)]
        public double[] gamm;

        /// float[4]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.R4)]
        public float[] user_mul;

        public uint shot_select;
        public float bright;
        public float threshold;
        public int half_size;
        public int four_color_rgb;
        public int document_mode;
        public int highlight;
        public int use_auto_wb;
        public int use_camera_wb;
        public int use_camera_matrix;
        public int output_color;

        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string output_profile;

        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string camera_profile;

        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string bad_pixels;

        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string dark_frame;

        public int output_bps;
        public int output_tiff;
        public int user_flip;
        public int user_qual;
        public int user_black;
        public int user_sat;
        public int med_passes;
        public float auto_bright_thr;
        public float adjust_maximum_thr;
        public int no_auto_bright;
        public int use_fuji_rotate;
        public int green_matching;
        public LibRaw_filtering filtering_mode;
        public int dcb_iterations;
        public int dcb_enhance_fl;
        public int fbdd_noiserd;
        public int eeci_refine;
        public int es_med_passes;
        public int ca_correc;
        public float cared;
        public float cablue;
        public int cfaline;
        public float linenoise;
        public int cfa_clean;
        public float lclean;
        public float cclean;
        public int cfa_green;
        public float green_thresh;
        public int exp_correc;
        public float exp_shift;
        public float exp_preser;
    }
}