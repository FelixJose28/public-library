using System;
using System.Collections.Generic;

namespace Library.Core.Models.Entities
{
    public class Alert: BaseEntity
    {
        public int AlertId { get; set; }
        public string Info { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
