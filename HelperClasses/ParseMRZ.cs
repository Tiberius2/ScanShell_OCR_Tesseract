using System;

namespace ScanShell_OCR.HelperClasses
{
    public class ParseMRZ
    {
        public static RomanianIDStructure ParserMRZLine1(string line1, CodeMapper mapper)
        {
            var model = new RomanianIDStructure
            {
                DocumentType = line1.Substring(0, 2).Replace("<", "").Trim(),
                IssuingCountry = mapper.GetCountryName(line1.Substring(2, 3).Replace("<", "").Trim())
            };

            string namesSection = line1.Substring(5, 31);
            string[] nameParts = namesSection.Split(new[] { "<<" }, StringSplitOptions.None);

            model.Surname = nameParts[0].Replace("<", " ").Trim();
            model.GivenName = nameParts.Length > 1 ? nameParts[1].Replace("<", " ").Trim() : "";

            return model;
        }

        public static void ParseMRZLine2(string line2, RomanianIDStructure model, CodeMapper mapper)
        {
            string rawSeries = line2.Substring(0, 9).Replace("<", "").Trim();
            model.IDSeries = rawSeries.Substring(0, 2);
            model.IDNumber = rawSeries.Substring(2);
            model.City = mapper.GetCountyName(model.IDSeries);

            string nationalityCode = line2.Substring(10, 3);
            model.Nationality = mapper.GetNationality(nationalityCode);

            string dateOfBirth = line2.Substring(13, 6);
            model.DateOfBirth = Utilities.FormatMRZDate(dateOfBirth);

            string expiryDate = line2.Substring(21, 6);
            model.ExpiryDate = Utilities.FormatMRZDate(expiryDate);

            string genderChar = line2.Substring(20, 1);
            model.Gender = genderChar;

            model.CNP = Utilities.ReconstructCNPFromMRZ(line2, model.DateOfBirth, model.Gender);
        }
    }
}
