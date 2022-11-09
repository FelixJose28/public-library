namespace Library.Core.Dtos
{
    public class RegisterBookDto : BaseEntityDto
    {
        public int RegisterBookId { get; set; }
        public int BookStatusId { get; set; }
        public int BookId { get; set; }
    }
}
