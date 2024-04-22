namespace JurDocsWinForms.Model
{
    /// <summary>
    /// 
    /// </summary>
    internal class WorkSession
    {
        private readonly CurrentUser _user;

        public WorkSession(CurrentUser user)
        {
            _user = user;
        }

        internal CurrentUser User => _user;

        public void AddNewDoc(string fileName)
        {


        }

        public void AddNewDocSource(string fileName)
        {

        }

    }
}
