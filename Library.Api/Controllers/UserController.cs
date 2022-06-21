using AutoMapper;
using Library.Core.Models.DTO;
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
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        [Authorize(Roles = CRole.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _unitOfWork._userRepository.GetAllAsync();
            if (!users.Any()) return NotFound("There aren't user");
            return Ok();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var user = await _unitOfWork._userRepository.GetByIdAsync(id);
            return Ok(user);
        }

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
                return Created(nameof(GetByIdAsync), user);
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _unitOfWork._userRepository.Update(user);

            var login = MapUserToLogin(user);
            _unitOfWork._loginRepository.Update(login);
            await _unitOfWork.CommitAsync();
            return NoContent();
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
