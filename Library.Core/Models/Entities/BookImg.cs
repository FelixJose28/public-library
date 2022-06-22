using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Models.Entities
{
    public class BookImg
    {
        public BookImg()
        {
            Books = new HashSet<Book>();
        }

        public int BookImgId { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string Route { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? RegistrationStatus { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
