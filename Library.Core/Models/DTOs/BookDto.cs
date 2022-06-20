﻿using System;
using System.Collections.Generic;

namespace Library.Core.Models.DTO
{
    public class BookDto : BaseEntityDto
    {
        public int BookId { get; set; }
        public string ImgUrl { get; set; }
        public string Edition { get; set; }
        public string Isbn { get; set; }
        public int AuthorId { get; set; }
        public int? PublisherId { get; set; }
        public int? LiteraryGenderId { get; set; }
    }
}