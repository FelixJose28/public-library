using System;
using System.Collections.Generic;

namespace Library.Core.Models.DTO
{
    public class PublisherDto : BaseEntityDto
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
    }
}
