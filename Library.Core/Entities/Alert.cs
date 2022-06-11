using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    public class Alert
    {
        public int AlertId { get; set; }
        public string Info { get; set; }
        public string Title { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? RegistrationStatus { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
