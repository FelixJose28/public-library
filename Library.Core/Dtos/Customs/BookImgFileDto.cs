using Microsoft.AspNetCore.Http;

namespace Library.Core.Dtos.Customs
{
    public class BookImgFileDto : BaseEntityDto
    {
        public int BookImgId { get; set; }
        public IFormFile Document { get; set; }
    }
}
