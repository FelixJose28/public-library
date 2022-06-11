﻿using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    public class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public int PublisherId { get; set; }
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
