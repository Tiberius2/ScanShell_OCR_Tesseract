using Tesseract;
using OpenCvSharp;


namespace ScanShell_OCR.HelperClasses
{
    public static class OCRService
    {
        public static string ExtractText(string imagePath, string tessDataPath, string debugImageOutputPath = null)
        {
            string result = "";

            using (var engine = new TesseractEngine(tessDataPath, "ron+eng", EngineMode.LstmOnly))
            using (var img = Pix.LoadFromFile(imagePath))
            {
                if (debugImageOutputPath != null)
                {
                    using (var page = engine.Process(img))
                    using (var iter = page.GetIterator())
                    {
                        iter.Begin();
                        Mat debugImage = Cv2.ImRead(imagePath);

                        do
                        {
                            if (iter.TryGetBoundingBox(PageIteratorLevel.Word, out Tesseract.Rect bbox))
                            {
                                var rect = new OpenCvSharp.Rect(bbox.X1, bbox.Y1, bbox.Width, bbox.Height);
                                Cv2.Rectangle(debugImage, rect, Scalar.Red, 2);
                            }
                        }
                        while (iter.Next(PageIteratorLevel.Word));

                        Cv2.ImWrite(debugImageOutputPath, debugImage);
                    }
                }

                using (var page = engine.Process(img, PageSegMode.SingleBlock))
                {
                    result = page.GetText();
                }
            }

            return result;
        }
    }
}
