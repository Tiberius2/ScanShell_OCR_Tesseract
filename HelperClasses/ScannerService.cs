using System;
using System.IO;
using WIA;

namespace ScanShell_OCR.HelperClasses
{
    public static class ScannerService
    {
        public static string ScanImage(string outputPath)
        {
            var deviceManager = new DeviceManager();
            Device scanner = null;

            for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
            {
                if (deviceManager.DeviceInfos[i].Type == WiaDeviceType.ScannerDeviceType)
                {
                    scanner = deviceManager.DeviceInfos[i].Connect();
                    break;
                }
            }

            if (scanner == null)
                throw new Exception("No scanner device found.");

            var item = scanner.Items[1];

            item.Properties["4103"].set_Value(3);
            item.Properties["4104"].set_Value(24);
            item.Properties["6147"].set_Value(400);
            item.Properties["6148"].set_Value(400);
            item.Properties["6149"].set_Value(0);
            item.Properties["6150"].set_Value(0);
            item.Properties["6151"].set_Value(1660);
            item.Properties["6152"].set_Value(1024);

            var imageFile = (ImageFile)item.Transfer("{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}"); // TIFF
            File.WriteAllBytes(outputPath, (byte[])imageFile.FileData.get_BinaryData());

            return outputPath;
        }
    }
}
