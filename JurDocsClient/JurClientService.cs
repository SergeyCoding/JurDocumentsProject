using LexExchangeApi.Clients;
using System.Net.Http.Headers;
using System.Text;

namespace JurDocsClient
{
    /// <summary>
    /// 
    /// </summary>
    public static class JurClientService
    {
        private const string _baseUrl = "http://localhost:5580";

        /// <summary>
        /// 
        /// </summary>
        public static Client JurDocsClientFactory() => JurDocsClientFactory(Guid.Empty);
        public static Client JurDocsClientFactory(Guid token) => JurDocsClientFactory("root", "root", _baseUrl, token);

        /// <summary>
        /// 
        /// </summary>
        public static Client JurDocsClientFactory(string name, string password, string url, Guid token)
        {
            var encodedAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{name}:{password}"));
            var auth = new AuthenticationHeaderValue("Basic", encodedAuth);

            var httpClient = new HttpClient();
            if (token == Guid.Empty)
            {
                httpClient.DefaultRequestHeaders.Authorization = auth;
            }
            else
            {
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("", token.ToString());
                httpClient.DefaultRequestHeaders.Add("Authorization", token.ToString());
            }

            return new Client(url, httpClient);
        }
    }
}
