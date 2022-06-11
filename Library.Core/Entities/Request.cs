using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    public class Request
    {
        public int RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? DeliverDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? RegistrationStatus { get; set; }
        public int UserId { get; set; }
        public int RegisterBookId { get; set; }

        public virtual RegisterBook RegisterBook { get; set; }
        public virtual User User { get; set; }
    }
}
