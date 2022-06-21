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
    public class RoleController : GenericController<Role, RoleDto, IRoleRepository,IUnitOfWork>
    {
        public RoleController(IRoleRepository repository, IMapper mapper,IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
            
        }
    }
}
