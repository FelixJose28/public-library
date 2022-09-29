﻿using AutoMapper;
using Library.Core.Interfaces;
using Library.Core.Dtos;
using Library.Core.Entities;
using Library.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksStatusController : GenericController<BookStatus, BookStatusDto, IBookStatusRepository,IUnitOfWork>
    {
        public BooksStatusController(IBookStatusRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IMemoryCache memoryCache) : base(repository, mapper, unitOfWork, memoryCache, true,24)
        {
        }
    }
}
