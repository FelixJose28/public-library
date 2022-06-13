using System;
using System.Collections.Generic;

namespace Library.Core.DTOs
{
    public class AuthorDto: BaseEntityDto
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
    }
}
