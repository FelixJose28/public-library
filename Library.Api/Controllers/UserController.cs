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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAll());
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.AddAsync(user);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = user.UserId},user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.UpdateAsync(user);
            return NoContent();
        }
    }
}
