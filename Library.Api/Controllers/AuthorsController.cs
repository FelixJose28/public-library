using AutoMapper;
using Library.Core.CustomEntities.Pagination;
using Library.Core.Dtos;
using Library.Core.Entities;
using Library.Core.Interfaces.Infrastructure;
using Library.Core.Interfaces.Services;
using Library.Core.QueryFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IAuthorService _authorService;
        private readonly IUriService _uriService;

        public AuthorsController(
            IMapper mapper,
            IMemoryCache memoryCache,
            IAuthorService authorService,
            IUriService uriService)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _authorService = authorService;
            _uriService = uriService;
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetAllAsync))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync([FromQuery] AuthorQueryFilter filters)
        {
            var authors = await _authorService.GetAuthorsAsync(filters);
            if (!authors.Any()) return NotFound("There aren't authors registered");
            var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);
            var metadata = new Metadata
            {
                TotalCount = authors.TotalCount,
                PageSize = authors.PageSize,
                CurrentPage = authors.CurrentPage,
                TotalPages = authors.TotalPages,
                HasNextPage = authors.HasNextPage,
                HasPreviousPage = authors.HasPreviousPage,
                NextPageUrl = _uriService.GetPostPaginationUri(filters, Url.RouteUrl(nameof(GetAllAsync))).ToString(),
                PreviousPageUrl = _uriService.GetPostPaginationUri(filters, Url.RouteUrl(nameof(GetAllAsync))).ToString(),
            };
            Response.Headers.Add("x-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(authorsDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var author = await _authorService.GetAuthorAsync(id);
            if (author is null) return NotFound("Author not found");
            var authorDto = _mapper.Map<AuthorDto>(author);
            return Ok(authorDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddAsync(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            await _authorService.AddAuthorAsync(author);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = author.AuthorId }, authorDto);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAsync(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            await _authorService.UpdateAuthorAsync(author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var author = await _authorService.GetAuthorAsync(id);
            if (author is null) return NotFound("Author not found");
            await _authorService.RemoveAuthorAsync(id);
            return NoContent();
        }

    }
}

//public class AuthorsController : GenericController<Author, AuthorDto, IAuthorRepository, IUnitOfWork>
//{
//    public AuthorsController(
//        IAuthorRepository repository,
//        IMapper mapper,
//        IUnitOfWork unitOfWork,
//        IMemoryCache memoryCache,
//        IAuthorService authorService) : base(repository, mapper, unitOfWork, memoryCache, false)
//    {
//    }

//}