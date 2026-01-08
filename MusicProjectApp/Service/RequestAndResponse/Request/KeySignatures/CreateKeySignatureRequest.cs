namespace Service.RequestAndResponse.Request.KeySignatures
{
    public class CreateKeySignatureRequest
    {
        public string KeyName { get; set; }
        public string Mode { get; set; }
        public int AccidentalCount { get; set; }
    }
}
