namespace JurDocs.Server.Model.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public class DataResponse<T>
    {
        private readonly StatusDataResponse _status;

        public DataResponse(StatusDataResponse status)
        {
            _status = status;
        }

        public DataResponse(T data) : this(StatusDataResponse.OK) => Data.Add(data);
        public DataResponse(StatusDataResponse status, string message) : this(status)
        {
            MessageToUser = message;
        }

        public List<T> Data { get; set; } = [];

        public string Status => _status.Value;

        public IEnumerable<string> Errors { get; set; } = [];

        public string MessageToUser { get; set; } = string.Empty;
    }
}
