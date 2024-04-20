
namespace JurDocs.WinForms.Model
{
    public class ProjectListTable : IComparable<ProjectListTable>, IComparable
    {
        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectFullName { get; set; }
        public string? Owner { get; internal set; }

        public int CompareTo(ProjectListTable? other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            return Id - other.Id;
        }

        public int CompareTo(object? obj)
        {
            if (obj is not ProjectListTable other)
                throw new ArgumentNullException(nameof(obj));

            return CompareTo(other);
        }

        public override bool Equals(object? obj)
        {
            return obj is ProjectListTable table &&
                   Owner == table.Owner;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Owner);
        }
    }
}
