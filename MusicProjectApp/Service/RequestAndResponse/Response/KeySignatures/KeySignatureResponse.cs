namespace Service.RequestAndResponse.Response.KeySignatures
{
    public class KeySignatureResponse
    {
        public int KeySignatureID { get; set; }
        public string KeyName { get; set; }
        public string Mode { get; set; }
        public int AccidentalCount { get; set; }
    }
}
