using JurDocs.Client;

namespace JurDocs.WinForms.ViewModel
{
    internal class MainViewModel(JurDocsClient client)
    {

        internal async Task<JurDocProject[]> GetProjectList()
        {
            var swaggerResponse = await client.ProjectAllAsync();
            return [.. swaggerResponse.Result.Where(x => !string.IsNullOrWhiteSpace(x.Name))];
        }

        internal async Task<string[]> GetProjectNameList()
        {
            var swaggerResponse = await client.ProjectAllAsync();
            return [.. swaggerResponse.Result.Select(x => x.Name).Where(x => !string.IsNullOrWhiteSpace(x))];
        }
    }
}
