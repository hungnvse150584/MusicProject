namespace Service.RequestAndResponse.Response.Songs
{
    public class SongResponse
    {
        public int SongID { get; set; }
        public string AccountID { get; set; }
        public string Name { get; set; }
        public string Composer { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }
}
