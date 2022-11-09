﻿using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksStatusController : GenericController<BookStatus, BookStatusDto, IBookStatusRepository, IUnitOfWork>
    {
        public BooksStatusController(IBookStatusRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IMemoryCache memoryCache) : base(repository, mapper, unitOfWork, memoryCache, true, 24)
        {
        }
    }
}
