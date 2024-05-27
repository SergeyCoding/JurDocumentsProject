using JurDocs.Common.EnumTypes;

namespace JurDocs.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    internal class JurDocsFileName
    {
        private readonly string _projectName;
        private readonly JurDocType _docType;
        private readonly int _docId;

        public JurDocsFileName(string projectName, JurDocType docType, int docId)
        {
            _projectName = projectName;
            _docType = docType;
            _docId = docId;
        }

        public string CreateFileName()
        {
            var fn = $"{_projectName}_{_docType.GetDescription()}_{_docId}";
            return Path.Combine(_projectName, _docType.GetDescription(), fn);
        }
    }
}