using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelephonesController : GenericController<Telephone, TelephoneDto, ITelephoneRepository, IUnitOfWork>
    {
        public TelephonesController(ITelephoneRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IMemoryCache memoryCache) : base(repository, mapper, unitOfWork, memoryCache, false)
        {

        }
    }
}
