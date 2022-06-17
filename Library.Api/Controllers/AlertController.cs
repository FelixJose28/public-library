using AutoMapper;
using Library.Core.DTOs;
using Library.Core.Entities;
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
    public class AlertController : GenericController<Alert, AlertDto, IAlertRepository>
    {
        public AlertController(IAlertRepository repository, IMapper mapper) : base(repository, mapper)
        {
            
        }
    }
}
