﻿using System;

namespace Library.Core.Dtos
{
    public class RequestDto : BaseEntityDto
    {
        public int RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? DeliverDate { get; set; }
        public int UserId { get; set; }
        public int RegisterBookId { get; set; }
    }
}
