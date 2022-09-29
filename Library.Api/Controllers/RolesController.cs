using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : GenericController<Role, RoleDto, IRoleRepository,IUnitOfWork>
    {
        public RoleController(IRoleRepository repository, IMapper mapper,IUnitOfWork unitOfWork, IMemoryCache memoryCache) : base(repository, mapper, unitOfWork,memoryCache,true)
        {
            
        }
    }
}
