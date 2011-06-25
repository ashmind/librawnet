using System;
using System.Collections.Generic;

using LibRawNet.Native;

namespace LibRawNet.Internal {
    internal class GammaAlgorithm {
        public static void Histogram(libraw_data_t data) {
            var t_white = 0x995; // this was actually a 0x2000, 0x995 is just a temp value suitable for ARW
            int c;

            //var perc = (int)(data.sizes.width * data.sizes.height * 0.01);
            //if (?.fuji_width) perc /= 2;

            //if (!((data.@params.highlight & ~2) || data.@params.no_auto_bright))
            //    for (t_white = c = 0; c < P1.colors; c++) {
            //        int val;
            //        int total;
            //        for (val = 0x2000, total = 0; --val > 32; )
            //            if ((total += libraw_internal_data.output_data.histogram[c][val]) > perc) break;
            //        if (t_white < val) t_white = val;
            //    }

            GammaCurve(
                data.color.curve,
                data.@params.gamm[0],
                data.@params.gamm[1],
                (t_white << 3) / data.@params.bright
            );
        }

        // directly from libraw/dcraw, needs rewrite/clarification
        private static void GammaCurve(ushort[] curve, double pwr, double ts, double imax) {
            int i;
            var g = new double[6];
            var bnd = new[] {0.0, 0.0};

            g[0] = pwr;
            g[1] = ts;
            g[2] = g[3] = g[4] = 0;
            bnd[g[1] >= 1 ? 1 : 0] = 1;
            if (g[1] > 0 && (g[1]-1)*(g[0]-1) <= 0) {
                for (i=0; i < 48; i++) {
                    g[2] = (bnd[0] + bnd[1])/2;
                    if (g[0] > 0) {
                        bnd[(Math.Pow(g[2]/g[1], -g[0]) - 1)/g[0] - 1/g[2] > -1 ? 1 : 0] = g[2];
                    }
                    else {
                        bnd[g[2]/Math.Exp(1 - 1/g[2]) < g[1] ? 1 : 0] = g[2];
                    }
                }

                g[3] = g[2] / g[1];
                if (g[0] > 0)
                    g[4] = g[2] * (1/g[0] - 1);
            }
            if (g[0] > 0) {
                g[5] = 1/(g[1]*Square(g[3])/2 - g[4]*(1 - g[3]) +
                          (1 - Math.Pow(g[3], 1 + g[0]))*(1 + g[4])/(1 + g[0])) - 1;
            }
            else {
                g[5] = 1 / (g[1]*Square(g[3])/2 + 1 - g[2] - g[3] -	g[2]*g[3]*(Math.Log(g[3]) - 1)) - 1;
            }

            for (i=0; i < 0x10000; i++) {
                curve[i] = 0xffff;
                double r;
                if ((r = (double) i / imax) < 1)
                    curve[i] = (ushort)(0x10000 * (
                        (r < g[3] ? r*g[1] : (g[0] > 0 ? Math.Pow( r,g[0])*(1+g[4])-g[4]    : Math.Log(r)*g[2]+1))));
            }
        }

        private static double Square(double p0) {
            return p0*p0;
        }
    }
}