using System.Collections.Generic;

namespace Library.Core.Entities
{
    public class LiteraryGender : BaseEntity
    {
        public LiteraryGender()
        {
            Books = new HashSet<Book>();
        }

        public int LiteraryGenderId { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
