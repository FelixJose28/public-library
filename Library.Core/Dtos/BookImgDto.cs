using System;

namespace Library.Core.Dtos
{
    public class BookImgDto
    {
        public int BookImgId { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string Route { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? RegistrationStatus { get; set; }
    }
}
