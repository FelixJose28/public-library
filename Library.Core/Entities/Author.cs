using System.Collections.Generic;

namespace Library.Core.Entities
{
    public class Author : BaseEntity
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
