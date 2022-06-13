using System;
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
        public DateTime RegistrationDate { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? RegistrationStatus { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
