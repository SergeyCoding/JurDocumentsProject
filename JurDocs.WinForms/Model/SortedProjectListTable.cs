using System.ComponentModel;

namespace JurDocs.WinForms.Model
{
    /// <summary>
    /// 
    /// </summary>
    internal class SortedProjectListTable : BindingList<ProjectListTable>
    {
        private bool _isSorted;

        protected override bool IsSortedCore => _isSorted;
        protected override bool SupportsSearchingCore => true;
        protected override ListSortDirection SortDirectionCore { get; }
        protected override PropertyDescriptor SortPropertyCore { get; }


        public SortedProjectListTable(IList<ProjectListTable> list) : base(list)
        {
        }

        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            var items = Items.ToList();

            if (items != null)
            {
                items.Sort((x, y) => x.Id - y.Id);
                _isSorted = true;
            }else
            {
                _isSorted = false;
            }

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            _isSorted = false;
        }
    }
}
