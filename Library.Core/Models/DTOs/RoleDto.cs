using System;
using System.Collections.Generic;

namespace Library.Core.Models.Dtos
{
    public class RoleDto : BaseEntityDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
