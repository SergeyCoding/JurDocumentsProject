namespace JurDocs.Server.Model.Responses
{
    /// <summary>
    /// Ответ в строковом виде
    /// </summary>
    public class StringResponse(string data)
    {
        public string Data => data;
    }
}
