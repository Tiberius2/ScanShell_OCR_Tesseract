namespace ScanShell_OCR.HelperClasses
{
    public class Utilities
    {
        public static string ReconstructCNPFromMRZ(string line2, string fullDateOfBirth, string gender)
        {
            string suffix = line2.Substring(29, 6);

            string dobMRZ = line2.Substring(13, 6);
            string yy = dobMRZ.Substring(0, 2);
            string mm = dobMRZ.Substring(2, 2);
            string dd = dobMRZ.Substring(4, 2);

            string sDigit = DetermineGenderCNPDigit(gender, fullDateOfBirth);

            return $"{sDigit}{yy}{mm}{dd}{suffix}";
        }

        public static string FormatMRZDate(string rawDate)
        {
            if (rawDate.Length != 6) return rawDate;
            int year = int.Parse(rawDate.Substring(0, 2));
            string century = (year >= 50) ? "19" : "20";
            return $"{century}{rawDate.Substring(0, 2)}-{rawDate.Substring(2, 2)}-{rawDate.Substring(4, 2)}";
        }

        private static string DetermineGenderCNPDigit(string gender, string dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(gender) || dateOfBirth.Length < 4)
                return "9";

            int year = int.Parse(dateOfBirth.Substring(0, 4));
            bool isMale = gender.ToUpper() == "M";

            if (year >= 1800 && year <= 1899)
                return isMale ? "3" : "4";
            if (year >= 1900 && year <= 1999)
                return isMale ? "1" : "2";
            if (year >= 2000 && year <= 2099)
                return isMale ? "5" : "6";

            return "9";
        }

    }
}
