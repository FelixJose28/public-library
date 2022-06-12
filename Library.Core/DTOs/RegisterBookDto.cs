using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    public class RegisterBookDto
    {
        public int RegisterBookId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? RegistrationStatus { get; set; }
        public int BookStatusId { get; set; }
        public int BookId { get; set; }
    }
}
