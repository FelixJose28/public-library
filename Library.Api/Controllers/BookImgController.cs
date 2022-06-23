using AutoMapper;
using Library.Core.Interfaces;
using Library.Core.Models.Dtos;
using Library.Core.Models.Dtos.Customs;
using Library.Core.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookImgController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookImgRepository _bookImgRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public BookImgController(
            IMapper mapper,
            IBookImgRepository bookImgRepository,
            IUnitOfWork unitOfWork,
            IConfiguration configuration
            )
        {
            _mapper = mapper;
            _bookImgRepository = bookImgRepository;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            var books = await _unitOfWork._bookImgRepository.GetAllAsync();
            if (!books.Any()) return NotFound("There aren't books registered");
            var booksDto = _mapper.Map<IEnumerable<BookImgDto>>(books);
            return Ok(booksDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var book = await _unitOfWork._bookImgRepository.GetByIdAsync(id);
            if (book == null) return NotFound($"Boo not found");
            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromForm] BookImgFileDto bookImgPostDto)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                string postFix = _configuration.GetValue<string>("ProjectRoot:UploadFile");
                string filePath = GetFilePath(@$"\{postFix}\", bookImgPostDto.Document);
                await UploadFile(filePath, bookImgPostDto.Document);
                BookImg bookImg = BookImgFileDtoToBookImg(bookImgPostDto, filePath, true);
                await _unitOfWork._bookImgRepository.AddAsync(bookImg);
                await _unitOfWork.CommitAsync();
                scope.Complete();
                return Created(nameof(GetByIdAsync), bookImg);
            }

        }

        [HttpPut]
        public async Task<IActionResult> UploadAsync([FromForm] BookImgFileDto bookImgPostDto)
        {
            BookImg bookImgCheck = await _unitOfWork._bookImgRepository.GetByIdAsync(bookImgPostDto.BookImgId);
            if (bookImgCheck == null) return NotFound("BookImg id not found");
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                string postFix = _configuration.GetValue<string>("ProjectRoot:UploadFile");
                string filePath = GetFilePath(@$"\{postFix}\", bookImgPostDto.Document);
                await UploadFile(filePath, bookImgPostDto.Document);
                DeleteFile(bookImgCheck.Route);
                BookImg bookImg = BookImgFileDtoToBookImg(bookImgPostDto, filePath,false);
                _unitOfWork._bookImgRepository.Update(bookImg);
                await _unitOfWork.CommitAsync();
                scope.Complete();
                return Created(nameof(GetByIdAsync), bookImg);
            }

        }

        private BookImg BookImgFileDtoToBookImg(BookImgFileDto bookImgPostDto, string route, bool postVerb)
        {
            return new BookImg
            {
                BookImgId = postVerb ? 0 : bookImgPostDto.BookImgId,
                FileName = Path.GetFileNameWithoutExtension(bookImgPostDto.Document.FileName),
                Extension = Path.GetExtension(bookImgPostDto.Document.FileName),
                Route = route,
                RegistrationDate = bookImgPostDto.RegistrationDate,
                RegisteredBy = bookImgPostDto.RegisteredBy,
                ModificationDate = bookImgPostDto.ModificationDate,
                ModifiedBy = bookImgPostDto.ModifiedBy,
                RegistrationStatus = bookImgPostDto.RegistrationStatus,
            };
        }
        private string GetFilePath(string rootPostFix, IFormFile file)
        {
            var root = $@"{System.IO.Directory.GetCurrentDirectory()}{rootPostFix}";
            if (!System.IO.Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            var filePath = $"{root}{file.FileName}";
            return filePath;
        }
        private async Task UploadFile(string filePath, IFormFile file)
        {
            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }
        }
        private void DeleteFile(string route)
        {
            System.IO.File.Delete(route);
        }
    }
}
