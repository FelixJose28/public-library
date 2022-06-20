using System;
using System.Collections.Generic;

namespace Library.Core.Models.Entities
{
    public class Request : BaseEntity
    {
        public int RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? DeliverDate { get; set; }
        public int UserId { get; set; }
        public int RegisterBookId { get; set; }

        public virtual RegisterBook RegisterBook { get; set; }
        public virtual User User { get; set; }
    }
}
