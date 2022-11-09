using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Library.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlertsController : GenericController<Alert, AlertDto, IAlertRepository, IUnitOfWork>
    {
        public AlertsController(IAlertRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IMemoryCache memoryCache) : base(repository, mapper, unitOfWork, memoryCache, false)
        {

        }
    }
}
