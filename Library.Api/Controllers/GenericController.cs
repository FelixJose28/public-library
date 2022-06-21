using AutoMapper;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    /// <summary>
    /// A generic implementation of a <a cref="ControllerBase"/> with a mapper, that provides operations for POST, PUT, GET,
    /// this requires the type of the entity, the entity data transfer object and the repository used for the entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to store in the repositoy.</typeparam>
    /// <typeparam name="TEntityDto">The type of the entity data transfer object.</typeparam>
    /// <typeparam name="TRepository">The type of the repository.</typeparam>
    /// <typeparam name="TUnitOfWork">Unit of work for all the repositories</typeparam>
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


        /// <summary>
        /// Get all  
        /// </summary>
        /// <returns>List of entity</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            if (!entities.Any()) return NotFound($"There aren't {typeof(TEntity).Name}");
            var entitiesDto = _mapper.Map<IEnumerable<TEntityDto>>(entities);
            return Ok(entitiesDto);
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An entity</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound($"{typeof(TEntity).Name} not found");
            var entityDto = _mapper.Map<TEntityDto>(entity);
            return Ok(entityDto);
        }

        /// <summary>
        /// Add a entity
        /// </summary>
        /// <param name="entityDto">The entity data transfer object</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return Created(nameof(GetByIdAsync),entity);
        }

        /// <summary>
        /// Update a entity
        /// </summary>
        /// <param name="entityDto">The entity data transfer object</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            return NoContent();
        }
    }
}
