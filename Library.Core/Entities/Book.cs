using System.Collections.Generic;

namespace Library.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book()
        {
            RegisterBooks = new HashSet<RegisterBook>();
        }

        public int BookId { get; set; }
        public string Edition { get; set; }
        public string Isbn { get; set; }
        public int AuthorId { get; set; }
        public int? PublisherId { get; set; }
        public int? LiteraryGenderId { get; set; }
        public int? BookImgId { get; set; }

        public virtual Author Author { get; set; }
        public virtual LiteraryGender LiteraryGender { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual BookImg BookImg { get; set; }
        public virtual ICollection<RegisterBook> RegisterBooks { get; set; }
    }
}
