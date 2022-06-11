using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    public class LiteraryGender
    {
        public LiteraryGender()
        {
            Books = new HashSet<Book>();
        }

        public int LiteraryGenderId { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? RegistrationStatus { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
