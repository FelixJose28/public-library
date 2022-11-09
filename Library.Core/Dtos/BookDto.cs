namespace Library.Core.Dtos
{
    public class BookDto : BaseEntityDto
    {
        public int BookId { get; set; }
        public string Edition { get; set; }
        public string Isbn { get; set; }
        public int AuthorId { get; set; }
        public int? PublisherId { get; set; }
        public int? LiteraryGenderId { get; set; }
        public int? BookImgId { get; set; }
    }
}
