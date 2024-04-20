using JurDocs.Client;
using JurDocs.Common.Operations;

namespace JurDocs.Core.Operations.ChangeCurrentProjectOperation
{
    /// <summary>
    /// 
    /// </summary>
    public class ChangeCurrentProject() : IOperation<ChangeCurrentProjectContext>
    {
        public async Task ExecuteAsync(ChangeCurrentProjectContext context)
        {
            if (context.ProjectId == 0)
            {
                context.State.CurrentProject = new JurDocProject { Id = 0 };
            }

            var jurDocProject = (await context.State.Client.ProjectAllAsync()).Result.First(x => x.Id == context.ProjectId);

            context.State.CurrentProject = jurDocProject;
        }
    }
}
