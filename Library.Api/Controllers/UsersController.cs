using AutoMapper;
using Library.Core.Models.Dtos;
using Library.Core.Models.Entities;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Core.Models.Constants;
using Microsoft.AspNetCore.Authorization;
using System.Transactions;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //[Authorize(Roles = CRole.Admin)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var users = await _unitOfWork._userRepository.GetAllAsync();
            if (!users.Any()) return NotFound("There aren't user");
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(usersDto);
        }

        //[Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var user = await _unitOfWork._userRepository.GetByIdAsync(id);
            if (user == null) return NotFound("User not found");
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IActionResult> AddAsync(UserDto userDto)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var user = _mapper.Map<User>(userDto);
                await _unitOfWork._userRepository.AddAsync(user);

                await _unitOfWork.CommitAsync();
                var login = MapUserToLogin(user);
                await _unitOfWork._loginRepository.AddAsync(login);
                await _unitOfWork.CommitAsync();
                scope.Complete();
                scope.Dispose();
                return Created(nameof(GetByIdAsync), user);
            }
        }

        //[Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var user = _mapper.Map<User>(userDto);
                _unitOfWork._userRepository.Update(user);

                var login = MapUserToLogin(user);
                _unitOfWork._loginRepository.Update(login);
                await _unitOfWork.CommitAsync();
                scope.Complete();
                scope.Dispose();
                return NoContent();

            }
        }

        private Login MapUserToLogin(User user)
        {
            return new Login
            {
                LoginId = 0,
                Email = user.Email,
                Password = user.Password,
                UserId = user.UserId,
                RegistrationDate = user.RegistrationDate,
                RegisteredBy = user.RegisteredBy,
                ModificationDate = user.ModificationDate,
                ModifiedBy = user.ModifiedBy,
                RegistrationStatus = user.RegistrationStatus
            };
        }
    }
}
