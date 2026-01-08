namespace Service.RequestAndResponse.Request.Songs
{
    public class CreateSongRequest
    {
        public string AccountID { get; set; }
        public string Name { get; set; }
        public string Composer { get; set; }
    }
}
