using JurDocs.Client;

namespace JurDocs.Core.Operations.ChangeCurrentProjectOperation
{

    public class ChangeCurrentProjectContext : AppStateContext
    {
        public int ProjectId { get; set; }
    }
}
