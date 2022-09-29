using System;
using System.Collections.Generic;

namespace Library.Core.Dtos
{
    public class TelephoneDto : BaseEntityDto
    {
        public int TelephoneId { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }
    }
}
