using AutoMapper;
using Library.Core.Models.Dtos;
using Library.Core.Models.Entities;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Library.Core.Interfaces.Services;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : GenericController<Author,AuthorDto,IAuthorRepository,IUnitOfWork>
    {
        public AuthorsController(
            IAuthorRepository repository, 
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IMemoryCache memoryCache,
            IAuthorService authorService) : base(repository, mapper, unitOfWork, memoryCache, false)
        {
        }

    }
}
