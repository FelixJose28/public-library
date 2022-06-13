using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    public class Publisher : BaseEntity
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
