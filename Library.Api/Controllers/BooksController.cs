﻿using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        public BooksController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IBookRepository bookRepository
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bookRepository = bookRepository;
        }


        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var books = await _unitOfWork._bookRepository.GetAllAsync();
            if (!books.Any()) return NotFound("There aren't books registered");
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);
            return Ok(booksDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var book = await _unitOfWork._bookRepository.GetByIdAsync(id);
            if (book is null) return NotFound("Book not found");
            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddAsync(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookRepository.AddAsync(book);
            await _unitOfWork.CommitAsync();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = book.AuthorId }, bookDto);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAsync(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _bookRepository.Update(book);
            await _unitOfWork.CommitAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book is null) return NotFound("Book not found");
            await _bookRepository.RemoveAsync(book.BookId);
            await _unitOfWork.CommitAsync();
            return NoContent();
        }

    }
}
