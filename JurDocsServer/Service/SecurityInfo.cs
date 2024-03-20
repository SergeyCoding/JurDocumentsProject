using JurDocsServer.Model;
using Newtonsoft.Json;

namespace JurDocsServer.Service
{
    /// <summary>
    /// Чтение информации об ограничениях директорий и пользователей
    /// </summary>
    public class SecurityInfoReader
    {
        public SecurityInfo GetSecurityInfo()
        {
            var dataJson = File.ReadAllText(@"Data\data.json");
            return JsonConvert.DeserializeObject<SecurityInfo>(dataJson) ?? new SecurityInfo();
        }
    }
}
