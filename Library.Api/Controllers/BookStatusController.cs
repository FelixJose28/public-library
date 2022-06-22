using AutoMapper;
using Library.Core.Interfaces;
using Library.Core.Models.Dtos;
using Library.Core.Models.Entities;
using Library.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookStatusController : GenericController<BookStatus, BookStatusDto, IBookStatusRepository,IUnitOfWork>
    {
        /// <summary>
        /// Test BookStatus
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public BookStatusController(IBookStatusRepository repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
        }
    }
}
