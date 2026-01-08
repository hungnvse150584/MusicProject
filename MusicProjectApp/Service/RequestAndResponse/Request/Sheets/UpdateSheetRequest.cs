namespace Service.RequestAndResponse.Request.Sheets
{
    public class UpdateSheetRequest
    {
        public string Author { get; set; }
        public int SongID { get; set; }
        public int TimeSignatureID { get; set; }
        public int KeySignatureID { get; set; }
    }
}
