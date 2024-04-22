namespace JurDocs.Server.Model.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public class DataResponse<T>
    {
        public T? Data { get; set; }

        public int Status { get; set; } = 0;

        public IEnumerable<string> Errors { get; set; } = [];

        public string MessageToUser { get; set; } = string.Empty;
    }
}
