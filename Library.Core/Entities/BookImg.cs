﻿using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    public class BookImg
    {
        public BookImg()
        {
            Books = new HashSet<Book>();
        }

        public int BookImgId { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string Route { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? RegistrationStatus { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
