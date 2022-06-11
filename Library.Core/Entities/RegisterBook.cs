using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    public class RegisterBook
    {
        public RegisterBook()
        {
            Requests = new HashSet<Request>();
        }

        public int RegisterBookId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? RegistrationStatus { get; set; }
        public int BookStatusId { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
        public virtual BookStatus BookStatus { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
