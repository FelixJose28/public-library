using System;
using System.Collections.Generic;

namespace Library.Core.Models.Dtos
{
    public class LiteraryGenderDto : BaseEntityDto
    {
        public int LiteraryGenderId { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
    }
}
