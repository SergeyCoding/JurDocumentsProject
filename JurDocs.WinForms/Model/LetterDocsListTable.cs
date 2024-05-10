namespace JurDocs.WinForms.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class LetterDocsListTable : IComparable<LetterDocsListTable>, IComparable
    {
        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public string? DocType { get; set; } = "Письмо";
        public DateTime DocDate { get; set; }
        public string? FileName { get; set; }
        public string? Note { get; internal set; }

        public int CompareTo(LetterDocsListTable? other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            return Id - other.Id;
        }

        public override bool Equals(object? obj)
        {
            return obj is LetterDocsListTable table &&
                   Id == table.Id &&
                   ProjectName == table.ProjectName &&
                   DocType == table.DocType &&
                   DocDate == table.DocDate &&
                   FileName == table.FileName &&
                   Note == table.Note;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, ProjectName, DocType, DocDate, FileName, Note);
        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(LetterDocsListTable left, LetterDocsListTable right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(LetterDocsListTable left, LetterDocsListTable right)
        {
            return !(left == right);
        }

        public static bool operator <(LetterDocsListTable left, LetterDocsListTable right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(LetterDocsListTable left, LetterDocsListTable right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(LetterDocsListTable left, LetterDocsListTable right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(LetterDocsListTable left, LetterDocsListTable right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
}
