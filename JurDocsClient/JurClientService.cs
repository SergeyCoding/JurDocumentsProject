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
        public static Client JurDocsClientFactory() => JurDocsClientFactory("api", "334455", _baseUrl);

        /// <summary>
        /// 
        /// </summary>
        public static Client JurDocsClientFactory(string name, string password, string url)
        {
            var encodedAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{name}:{password}"));
            var auth = new AuthenticationHeaderValue("Basic", encodedAuth);

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = auth;

            return new Client(url, httpClient);
        }
    }
}
