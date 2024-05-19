using JurDocs.Common.EnumTypes;
using JurDocs.Core.DI;
using JurDocs.Core.Model;
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Documents.Impl
{
    internal class CloseDocument : ICloseDocument
    {
        public async Task ExecuteAsync( EditedDocData data)
        {
            if (data.CloseType==CloseEditorType.Save)
            {
                await CoreContainer.Get<ISaveDocument>().ExecuteAsync( data);
            }
        }

    }
}
