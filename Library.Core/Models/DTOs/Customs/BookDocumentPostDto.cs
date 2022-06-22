using Library.Core.Models.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Models.DTOs
{
    public class BookDocumentPostDto:BookDto
    {
        public List<IFormFile> Documents { get; set; }
    }
}
