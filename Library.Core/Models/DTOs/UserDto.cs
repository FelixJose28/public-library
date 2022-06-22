using System;
using System.Collections.Generic;

namespace Library.Core.Models.Dtos
{
    public class UserDto : BaseEntityDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Province { get; set; }
        public string MunicipalDistrict { get; set; }
        public string Municipality { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public int RoleId { get; set; }
    }
}
