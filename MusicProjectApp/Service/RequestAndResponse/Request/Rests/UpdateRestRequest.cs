namespace Service.RequestAndResponse.Request.Rests
{
    public class UpdateRestRequest
    {
        public int MeasureID { get; set; }
        public float Duration { get; set; }
        public float StartBeat { get; set; }
    }
}
