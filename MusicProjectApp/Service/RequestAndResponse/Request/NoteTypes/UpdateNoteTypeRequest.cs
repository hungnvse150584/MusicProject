namespace Service.RequestAndResponse.Request.NoteTypes
{
    public class UpdateNoteTypeRequest
    {
        public int NoteID { get; set; }
        public string NoteTypeName { get; set; }
        public float Duration { get; set; }
    }
}
