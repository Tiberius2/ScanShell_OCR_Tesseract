using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace ScanShell_OCR
{
    public partial class MainForm : Form
    {
        private string currentImagePath = null;
        private bool hasSelectedImage = false;
        private string processedImagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Cropped_ID.jpg");
        private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Extracted_Text.txt");

        public MainForm()
        {
            InitializeComponent();
        }

        private void pipelineButton_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Scanning...";
                Application.DoEvents();
                string scanPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "NewScanned_ID.jpg");
                ScannerService.ScanImage(scanPath);
                picScannedImage.Image = Image.FromFile(scanPath);

                lblStatus.Text = "Preprocessing Image...";
                Application.DoEvents();
                string ProcessedImagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Processed_ID.jpg");
                ImageProcessing.PreprocessImage(scanPath, processedImagePath);
                cropedPicture.Image = Image.FromFile(processedImagePath);

                string tessDataPath = @"C:\Users\ionut.tiprigan\source\repos\DynamicDOTNET\packages\Tesseract.5.2.0\build\tessdata";
                string debugPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "OCR_Debug.jpg");

                lblStatus.Text = "Extracting text...";
                Application.DoEvents();
                var rawText = OCRService.ExtractText(processedImagePath, tessDataPath, debugPath);

                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Extracted_Text.txt");
                File.WriteAllText(filePath, rawText);
                txtExtractedText.Text = rawText;
                debugPicture.Image = Image.FromFile(debugPath);

                lblStatus.Text = "Parsing MRZ Lines...";
                Application.DoEvents();
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length < 2)
                {
                    MessageBox.Show("The MRZ file must contain at least 2 lines");
                    return;
                }
                string sharedFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\SharedResources");
                var mapper = new CodeMapper(
                    Path.Combine(sharedFolder, "CountryCodes.json"),
                    Path.Combine(sharedFolder, "CountyCodes.json"),
                    Path.Combine(sharedFolder, "Nationalities.json")
                );

                var result = ParseMRZ.ParserMRZLine1(lines[0], mapper);
                ParseMRZ.ParseMRZLine2(lines[1], result, mapper);

                string output = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ParsedMRZ_Lines.json");
                string json = JsonConvert.SerializeObject(result, Formatting.Indented);
                File.WriteAllText(output, json);

                lblStatus.Text = "Done!";
                Application.DoEvents();
                MessageBox.Show("ID scanned, extracted and parsed the MRZ lines sucessfully to: \n\n" + json);
            }
            catch (Exception ex)
            {
                lblStatus.Text = " ERROR!";
                MessageBox.Show("Pipeline failed: \n" + ex.Message);
            }
        }

        // SCAN BUTTON
        private void ScanButton_Click(object sender, EventArgs e)
        {

            try
            {
                lblStatus.Text = "Connecting to scanner...";
                string imagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Scanned_ID.jpg");
                ScannerService.ScanImage(imagePath);

                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                using (var tempImage = Image.FromStream(stream))
                {
                    picScannedImage.Image = new Bitmap(tempImage);
                }

                lblStatus.Text = "Scan successful!";
                MessageBox.Show($"Scan successful! Image saved at: {imagePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // CLEAR BUTTON
        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (picScannedImage.Image != null)
            {
                picScannedImage.Image.Dispose();
                picScannedImage.Image = null;
            }
            if (txtExtractedText.Text != null)
            {
                txtExtractedText.Text = null;
            }

            if (cropedPicture.Image != null)
            {
                cropedPicture.Image.Dispose();
                cropedPicture.Image = null;
            }
            lblStatus.Text = "Image cleared!";
            hasSelectedImage = false;
        }

        // EXTRACT BUTTON
        private void button3_Click(object sender, EventArgs e)
        {
            string rawImagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Scanned_ID.jpg");

            if (!File.Exists(rawImagePath))
            {
                MessageBox.Show("No scanned image found!");
                return;
            }

            string inputImage = hasSelectedImage ? currentImagePath : rawImagePath;
            ImageProcessing.PreprocessImage(inputImage, processedImagePath);

            string tessDataPath = @"C:\Users\ionut.tiprigan\source\repos\DynamicDOTNET\packages\Tesseract.5.2.0\build\tessdata";
            string debugImage = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "OCR_Debug.jpg");

            var rawText = OCRService.ExtractText(processedImagePath, tessDataPath, debugImage);
            txtExtractedText.Text = rawText;
            File.WriteAllText(filePath, rawText);

            picScannedImage.Image = Image.FromFile(processedImagePath);
            cropedPicture.Image = Image.FromFile(debugImage);
            lblStatus.Text = "Text extraction complete!";
        }

        // SELECT IMAGE
        private void button4_Click(object sender, EventArgs e)
        {
            if (picScannedImage.Image != null)
            {
                picScannedImage.Image.Dispose();
                picScannedImage.Image = null;
            }
            if (txtExtractedText.Text != null)
            {
                txtExtractedText.Text = null;
            }
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.tif)|*.jpg;*.jpeg;*.png;*.tif";
                openFileDialog.Title = "Select an image for OCR";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentImagePath = openFileDialog.FileName;
                    using (var fileStream = new FileStream(currentImagePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var img = Image.FromStream(fileStream))
                        {
                            picScannedImage.Image = new Bitmap(currentImagePath);
                        }
                    }
                    lblStatus.Text = "Image loaded from disk.";
                    hasSelectedImage = true;
                }
            }

        }


        // MRZ MAPPER BUTTON
        private void ParseMRZButton_Click(object sender, EventArgs e)
        {
            string outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "parsedMRZ.json");

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Extracted text file not found");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length < 2)
            {
                MessageBox.Show("The MRZ file should contain at least two lines.");
                return;
            }

            string line1 = lines[0];
            string line2 = lines[1];
            var mapper = new CodeMapper(
                "JsonFiles/CountryCodes.json",
                "JsonFiles/CountyCodes.json",
                "JsonFiles/Nationalities.json"
            );
            var result = ParseMRZ.ParserMRZLine1(line1, mapper);
            ParseMRZ.ParseMRZLine2(line2, result, mapper);

            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            File.WriteAllText(outputPath, json);

            MessageBox.Show("MRZ lines parsed and saved successfully: \n\n" + json);
        }
    }
}
