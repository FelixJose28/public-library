﻿using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    public class Book
    {
        public Book()
        {
            RegisterBooks = new HashSet<RegisterBook>();
        }

        public int BookId { get; set; }
        public string ImgUrl { get; set; }
        public string Edition { get; set; }
        public string Isbn { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? RegistrationStatus { get; set; }
        public int AuthorId { get; set; }
        public int? PublisherId { get; set; }
        public int? LiteraryGenderId { get; set; }

        public virtual Author Author { get; set; }
        public virtual LiteraryGender LiteraryGender { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<RegisterBook> RegisterBooks { get; set; }
    }
}
