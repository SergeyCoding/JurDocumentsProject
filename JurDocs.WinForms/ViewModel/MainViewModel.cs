using JurDocs.Client;

namespace JurDocs.WinForms.ViewModel
{
    internal class MainViewModel(JurDocsClient client)
    {

        internal async Task<string[]> GetProjectList()
        {
            var swaggerResponse = await client.ProjectAllAsync();
            return [.. swaggerResponse.Result.Select(x => x.Name).Where(x => !string.IsNullOrWhiteSpace(x))];
        }
    }
}
