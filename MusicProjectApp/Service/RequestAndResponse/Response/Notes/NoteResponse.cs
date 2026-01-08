namespace Service.RequestAndResponse.Response.Notes
{
    public class NoteResponse
    {
        public int NoteID { get; set; }
        public int MeasureID { get; set; }
        public string Pitch { get; set; }
        public int Octave { get; set; }
        public int Alter { get; set; }
        public float Duration { get; set; }
        public float StartBeat { get; set; }
        public bool IsChord { get; set; }
    }
}
