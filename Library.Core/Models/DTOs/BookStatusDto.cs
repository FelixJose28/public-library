using System;
using System.Collections.Generic;

namespace Library.Core.Models.DTO
{
    public class BookStatusDto : BaseEntityDto
    {
        public int BookStatusId { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
    }
}
