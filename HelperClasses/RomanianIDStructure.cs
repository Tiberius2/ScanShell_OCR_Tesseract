namespace ScanShell_OCR.HelperClasses
{
    public class RomanianIDStructure
    {
        // First line of MRZ
        public string DocumentType { get; set; }
        public string IssuingCountry { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }

        // Second line of MRZ
        public string IDSeries { get; set; }
        public string IDNumber { get; set; }
        public string City {  get; set; }
        public string Nationality { get; set; }  
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ExpiryDate { get; set; }
        public string CNP { get; set; }
    }
}
