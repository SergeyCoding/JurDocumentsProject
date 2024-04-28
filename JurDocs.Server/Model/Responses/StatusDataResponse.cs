namespace JurDocs.Server.Model.Responses
{
    public class StatusDataResponse(string value)
    {
        public string Value { get; } = value;

        public static StatusDataResponse OK { get; } = new StatusDataResponse("OK");
        public static StatusDataResponse BAD { get; } = new StatusDataResponse("BAD");
    }
}
