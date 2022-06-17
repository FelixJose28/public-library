using AutoMapper;
using Library.Core.Interfaces;
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
    public class GenericController<TEntity, TEntityDto, TRepository,TUnitOfWork> : ControllerBase
    where TEntity : class
    where TEntityDto : class
    where TRepository : IGenericRepository<TEntity>
    where TUnitOfWork : IUnitOfWork

    {
        private readonly TRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GenericController(
            TRepository repository, 
            IMapper mapper,
            IUnitOfWork unitOfWork
            )
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _repository.GetAll();
            if (!entities.Any()) return NotFound($"There aren't {typeof(TEntity).Name}");
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound($"{typeof(TEntity).Name} not found");
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return Created(nameof(GetByIdAsync),entity);
        }

        [HttpPut]
        public IActionResult UpdateAsync(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            _repository.Update(entity);
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}
