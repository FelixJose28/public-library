using System.Collections.Generic;

namespace Library.Core.Entities
{
    public class BookStatus : BaseEntity
    {
        public BookStatus()
        {
            RegisterBooks = new HashSet<RegisterBook>();
        }

        public int BookStatusId { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }

        public virtual ICollection<RegisterBook> RegisterBooks { get; set; }
    }
}
