using System;
using System.Collections.Generic;

namespace Library.Core.DTOs
{
    public class AlertDto: BaseEntityDto
    {
        public int AlertId { get; set; }
        public string Info { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
    }
}
