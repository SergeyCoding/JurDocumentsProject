namespace JurDocsWinForms.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkSession(CurrentUser user)
    {
        private readonly CurrentUser _user = user;

        internal CurrentUser User => _user;

        public void AddNewDoc(string fileName)
        {


        }

        public void AddNewDocSource(string fileName)
        {

        }

    }
}
