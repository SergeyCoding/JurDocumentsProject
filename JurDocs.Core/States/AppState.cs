using JurDocs.Client;
using JurDocs.Core.Constants;
using JurDocs.Core.Model;

namespace JurDocs.Core.States
{
    internal class AppState
    {
        private JurDocsClient? _client = null;

        private JurDocUser? _user;

        public JurDocUser User
        {
            get
            {
                if (_user == null)
                    throw new InvalidOperationException();

                return _user;
            }
            set => _user = value;
        }

        public AppPage CurrentPage { get; set; } = AppPage.Null;

        public JurDocProject CurrentProject { get; set; } = new JurDocProject { Id = 0 };
        public int CurrentDocumentId { get; set; }


        internal JurDocsClient Client
        {
            get
            {
                if (_client == null)
                    throw new InvalidOperationException();

                return _client;
            }

            set => _client = value;
        }

        public List<UserRight> CurrentProjectRights { get; set; } = [];
    }
}
