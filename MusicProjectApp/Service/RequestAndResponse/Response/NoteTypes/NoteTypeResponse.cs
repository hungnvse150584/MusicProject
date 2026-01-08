namespace Service.RequestAndResponse.Response.NoteTypes
{
    public class NoteTypeResponse
    {
        public int NoteTypeID { get; set; }
        public int NoteID { get; set; }
        public string NoteTypeName { get; set; }
        public float Duration { get; set; }
    }
}
