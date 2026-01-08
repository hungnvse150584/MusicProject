namespace Service.RequestAndResponse.Request.Notes
{
    public class UpdateNoteRequest
    {
        public int MeasureID { get; set; }
        public string Pitch { get; set; }
        public int Octave { get; set; }
        public int Alter { get; set; }
        public float Duration { get; set; }
        public float StartBeat { get; set; }
        public bool IsChord { get; set; }
    }
}
