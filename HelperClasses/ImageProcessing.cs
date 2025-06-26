using OpenCvSharp;
using System;

namespace ScanShell_OCR.HelperClasses
{
    public static class ImageProcessing
    {
        public static void PreprocessImage(string inputPath, string outputPath)
        {
            Mat gray = Cv2.ImRead(inputPath, ImreadModes.Grayscale);
            Mat final = new Mat();
            Cv2.FastNlMeansDenoising(gray, final, 30, 7, 31);
            Mat blurred = new Mat();
            Cv2.GaussianBlur(final, blurred, new Size(0, 0), 1.5);
            Cv2.AddWeighted(final, 1.8, blurred, -0.9, 0, final);
            Cv2.ConvertScaleAbs(final, final, alpha: 1.0, beta: 10);
            Cv2.BitwiseNot(final, final);


            Mat binarized = new Mat();
            Cv2.Threshold(final, binarized, 180, 210, ThresholdTypes.Binary | ThresholdTypes.Otsu);


            int x = 30, y = 760, width = 1660, height = 250;
            x = Math.Max(0, x);
            y = Math.Max(0, y);
            width = Math.Min(binarized.Width - x, width);
            height = Math.Min(binarized.Height - y, height);

            var roi = new Rect(x, y, width, height);
            Mat cropped = new Mat(final, roi);

            Cv2.ImWrite(outputPath, cropped);
        }
    }
}
