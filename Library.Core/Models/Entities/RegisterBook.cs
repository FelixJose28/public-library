using System;
using System.Collections.Generic;

namespace Library.Core.Models.Entities
{
    public class RegisterBook : BaseEntity
    {
        public RegisterBook()
        {
            Requests = new HashSet<Request>();
        }

        public int RegisterBookId { get; set; }
        public int BookStatusId { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
        public virtual BookStatus BookStatus { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
