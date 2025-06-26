using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ScanShell_OCR.HelperClasses
{
    public class CodeMapper
    {
        public Dictionary<string, string> CountryMap { get; private set; }
        public Dictionary<string, string> CountyMap { get; private set; }
        public Dictionary<string, string> NationalityMap { get; private set; }  

        public CodeMapper(string countryPath, string countyPath, string nationalityPath)
        {
            CountryMap = LoadMap(countryPath);
            CountyMap = LoadMap(countyPath);
            NationalityMap = LoadMap(nationalityPath);
        }

        private Dictionary<string, string> LoadMap(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show($"File not found: {path}");
                return new Dictionary<string, string>();
            }

            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

        }

        public string GetCountryName(string code) => CountryMap.TryGetValue(code, out var name) ? name : code;
        public string GetCountyName(string code) => CountyMap.TryGetValue(code, out var name) ? name : code;
        public string GetNationality(string code) => NationalityMap.TryGetValue(code,out var value) ? value : code; 

    }
}
