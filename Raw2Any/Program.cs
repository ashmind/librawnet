using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;

using LibRawNet;

namespace Raw2Any {
    public class Program {
        public static void Main(string[] args) {
            try {
                var rawFileName = args[0];
                var pngFileName = Path.ChangeExtension(rawFileName, "png");

                using (var raw = RawImage.FromFile(rawFileName))
                using (var bitmap = raw.ToBitmap()) {
                    bitmap.Save(pngFileName, ImageFormat.Png);
                }
            }
            catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.Write(ex);
                Console.ResetColor();
            }
        }
    }
}
