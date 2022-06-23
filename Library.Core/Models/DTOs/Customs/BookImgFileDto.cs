using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Models.Dtos.Customs
{
    public class BookImgFileDto:BaseEntityDto
    {
        public int BookImgId { get; set; }
        public IFormFile Document { get; set; }
    }
}
