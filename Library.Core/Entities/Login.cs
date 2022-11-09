﻿using System;

namespace Library.Core.Entities
{
    public class Login
    {
        public int LoginId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? RegistrationStatus { get; set; }

        public virtual User User { get; set; }
    }
}
