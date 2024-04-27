namespace JurDocs.Server.Model.Responses
{
    /// <summary>
    /// 
    /// </summary>

    public class DataResponse<T>()
    {
        public DataResponse(T data) : this() => Data.Add(data);
        public DataResponse(string status, string message) : this()
        {
            Status = status;
            MessageToUser = message;
        }

        public List<T> Data { get; set; } = [];

        public string Status { get; set; } = StatusDataResponse.OK;

        public IEnumerable<string> Errors { get; set; } = [];

        public string MessageToUser { get; set; } = string.Empty;
    }
}
