using System;
using System.Collections.Generic;

namespace Library.Core.Models.DTO
{
    public class RegisterBookDto : BaseEntityDto
    {
        public int RegisterBookId { get; set; }
        public int BookStatusId { get; set; }
        public int BookId { get; set; }
    }
}
