using AutoMapper;
using Library.Core.DTOs;
using Library.Core.Entities;
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
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _unitOfWork._userRepository.GetAllAsync();
            if (!users.Any()) return NotFound("There aren't user");
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var user = await _unitOfWork._userRepository.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _unitOfWork._userRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = user.UserId }, user);
        }

        [HttpPut]
        public IActionResult Update(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _unitOfWork._userRepository.Update(user);
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}
