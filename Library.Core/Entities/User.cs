﻿using System.Collections.Generic;

namespace Library.Core.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Alerts = new HashSet<Alert>();
            Requests = new HashSet<Request>();
            Telephones = new HashSet<Telephone>();
            Logins = new HashSet<Login>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
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
        public string UserCode { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Alert> Alerts { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Telephone> Telephones { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
    }
}
