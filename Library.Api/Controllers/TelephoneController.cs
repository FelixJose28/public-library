using AutoMapper;
using Library.Core.Models.DTO;
using Library.Core.Models.Entities;
using Library.Core.Interfaces;
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
    public class TelephoneController : GenericController<Telephone, TelephoneDto, ITelephoneRepository,IUnitOfWork>
    {
        public TelephoneController(ITelephoneRepository repository, IMapper mapper,IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
            
        }
    }
}
