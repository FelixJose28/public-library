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
    public class GenericController<TEntity, TEntityDto, TRepository> : ControllerBase
    where TEntity : class
    where TEntityDto : class
    where TRepository : IGenericRepository<TEntity>
    {
        private readonly TRepository _repository;
        private readonly IMapper _mapper;
        public GenericController(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            await _repository.AddAsync(entity);
            return Ok();
            //return CreatedAtAction(nameof(GetByIdAsync), new { id = entity. }, entity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            await _repository.UpdateAsync(entity);
            return NoContent();
        }
    }
}
