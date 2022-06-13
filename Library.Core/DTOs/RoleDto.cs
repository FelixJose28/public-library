using System;
using System.Collections.Generic;

namespace Library.Core.DTOs
{
    public class RoleDto : BaseEntityDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
