﻿using AutoMapper;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public abstract class GenericController<TEntity, TEntityDto, TRepository, TUnitOfWork> : ControllerBase
    where TEntity : class
    where TEntityDto : class
    where TRepository : IGenericRepository<TEntity>
    where TUnitOfWork : IUnitOfWork

    {
        private readonly TRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly bool _isForCache;
        private readonly int _cacheLifetimeHours;
        private readonly MemoryCacheEntryOptions _cacheOptions;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="memoryCache"></param>
        /// <param name="isForCache">You want to implement cache</param>
        /// <param name="cacheLifetimeHours">Expiration time in hours of cache</param>
        public GenericController(
            TRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IMemoryCache memoryCache,
            bool isForCache,
            int cacheLifetimeHours = 12
            )
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
            _isForCache = isForCache;
            _cacheLifetimeHours = cacheLifetimeHours;
            _cacheOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromMinutes(1000));
        }


        /// <summary>
        /// Get all   
        /// </summary>
        /// <returns>List of entity</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetAllAsync()
        {

            IEnumerable<TEntity> entities;
            if (_isForCache)
            {
                if (!_memoryCache.TryGetValue($"{typeof(TEntity).Name}s", out entities))
                {
                    entities = await _repository.GetAllAsync();
                    if (!entities.Any()) return NotFound($"There aren't {typeof(TEntity).Name}");
                    _memoryCache.Set($"{typeof(TEntity).Name}s", entities, _cacheOptions);
                }
            }
            else
            {
                entities = await _repository.GetAllAsync();
                if (!entities.Any()) return NotFound($"There aren't {typeof(TEntity).Name}");
            }

            var entitiesDto = _mapper.Map<IEnumerable<TEntityDto>>(entities);
            return Ok(entitiesDto);
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Primary key of the entity</param>
        /// <returns>An entity</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetByIdAsync(int id)
        {
            TEntity entity;
            if (_isForCache)
            {
                if (!_memoryCache.TryGetValue($"{typeof(TEntity).Name}", out entity))
                {
                    entity = await _repository.GetByIdAsync(id);
                    if (entity is null) return NotFound($"{typeof(TEntity).Name} not found");
                    _memoryCache.Set($"{typeof(TEntity).Name}", entity, _cacheOptions);
                }
            }
            else
            {
                entity = await _repository.GetByIdAsync(id);
                if (entity is null) return NotFound($"{typeof(TEntity).Name} not found");
            }
            var entityDto = _mapper.Map<TEntityDto>(entity);
            return Ok(entityDto);
        }

        /// <summary>
        /// Add an entity
        /// </summary>
        /// <param name="entityDto">The entity data transfer object</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public virtual async Task<IActionResult> AddAsync(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            _memoryCache.Remove($"{typeof(TEntity).Name}");
            _memoryCache.Remove($"{typeof(TEntity).Name}s");
            return Created(nameof(GetByIdAsync), entityDto);
        }

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entityDto">The entity data transfer object</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<IActionResult> UpdateAsync(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            _memoryCache.Remove($"{typeof(TEntity).Name}");
            _memoryCache.Remove($"{typeof(TEntity).Name}s");
            return NoContent();
        }

        /// <summary>
        /// Remove an entity
        /// </summary>
        /// <param name="id">Primary key of the entity</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) return NotFound($"{typeof(TEntity).Name} not found");
            await _repository.RemoveAsync(id);
            await _unitOfWork.CommitAsync();
            _memoryCache.Remove($"{typeof(TEntity).Name}");
            _memoryCache.Remove($"{typeof(TEntity).Name}s");
            return NoContent();
        }
    }
}
