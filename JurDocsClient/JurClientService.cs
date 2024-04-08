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
        private static string _baseUrl = "http://localhost:5580";

        public static string UrlBase { get => _baseUrl; set => _baseUrl = value; }

        /// <summary>
        /// 
        /// </summary>
        public static Client JurDocsClientFactory() => JurDocsClientFactory(Guid.Empty);
        public static Client JurDocsClientFactory(Guid token) => JurDocsClientFactory("root", "root", UrlBase, token);

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
