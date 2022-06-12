using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    public class TelephoneDto
    {
        public int TelephoneId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? RegistrationStatus { get; set; }
        public int UserId { get; set; }
    }
}
