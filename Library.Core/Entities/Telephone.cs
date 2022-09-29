using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    public class Telephone : BaseEntity
    {
        public int TelephoneId { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
