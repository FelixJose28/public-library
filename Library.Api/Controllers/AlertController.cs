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
using Microsoft.AspNetCore.Authorization;

namespace Library.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : GenericController<Alert, AlertDto, IAlertRepository,IUnitOfWork>
    {
        public AlertController(IAlertRepository repository, IMapper mapper,IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
            
        }
    }
}
