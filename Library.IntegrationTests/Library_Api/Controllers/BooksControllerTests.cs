using AutoFixture;
using AutoMapper;
using Library.Api.Controllers;
using Library.Core.Dtos;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Library.IntegrationTests.Library_Api.Controllers
{
    public class BooksControllerTests
    {
        private readonly BooksController _sut;
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
        private readonly Mock<IBookRepository> _bookRepository = new Mock<IBookRepository>();
        private readonly Fixture _fixture;
        private readonly MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDto>().ReverseMap());
        //this configuration will get AutoMapperProfile that contain all the mapping configuration for all the entities
        //private readonly MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>()); 
        private readonly IMapper _mapperReal;

        //The name of the method being tested.
        //The scenario under which it's being tested.
        //The expected behavior when the scenario is invoked
        public BooksControllerTests()
        {
            _sut = new BooksController(_unitOfWork.Object, _mapper.Object, _bookRepository.Object);
            _fixture = new Fixture();
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _mapperReal = config.CreateMapper();

        }

        [Fact]
        public async Task GetByIdAsync_WhenBookExists_ReturnBook()
        {
            //Arrange
            var book = _fixture.Create<Book>();
            var bookDto = _mapperReal.Map<BookDto>(book);
            int bookId = book.BookId;


            _unitOfWork.Setup(x => x._bookRepository.GetByIdAsync(bookId))
                .ReturnsAsync(book);

            _mapper.Setup(x => x.Map<BookDto>(book))
                .Returns(bookDto);

            //Atc
            var response = await _sut.GetByIdAsync(bookId);

            //Assert
            var result = (OkObjectResult)(response);
            Assert.IsType<OkObjectResult>(result);
            var bookReturn = result.Value as BookDto;
            Assert.IsType<BookDto>(bookReturn);
            Assert.Equal(bookId, bookReturn.BookId);
        }

        [Fact]
        public async Task GetByIdAsync_WhenBookNotExists_ReturnNotFound()
        {

            //Arrange
            int bookId = 1;
            _unitOfWork.Setup(x => x._bookRepository.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Atc
            var response = await _sut.GetByIdAsync(bookId);

            //Assert
            var result = Assert.IsType<NotFoundObjectResult>(response);
            var messageReturned = Assert.IsType<string>(result.Value);
            Assert.Equal("Book not found", messageReturned);
        }

        [Fact]
        public async Task GetAllAsync_WhenBooksExists_ReturnBooks()
        {

            //Arrange
            var bookList = _fixture.CreateMany<Book>().ToList();
            var bookListDto = _mapperReal.Map<IEnumerable<BookDto>>(bookList);

            _unitOfWork.Setup(x => x._bookRepository.GetAllAsync(default))
                 .ReturnsAsync(bookList);

            _mapper.Setup(x => x.Map<IEnumerable<BookDto>>(bookList))
                .Returns(bookListDto);

            //Atc
            var response = await _sut.GetAllAsync();

            //Assert
            var result = Assert.IsType<OkObjectResult>(response);
            var bookListReturn = Assert.IsAssignableFrom<IEnumerable<BookDto>>(result.Value);
            Assert.True(bookListReturn.Any());
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetAllAsync_WhenBooksNotExists_ReturnNotFound()
        {
            //Arrange
            _unitOfWork.Setup(x => x._bookRepository.GetAllAsync(default))
                .ReturnsAsync(new List<Book>());

            //Atc
            var response = await _sut.GetAllAsync();

            //Assert
            var result = Assert.IsType<NotFoundObjectResult>(response);
            var messageReturned = Assert.IsType<string>(result.Value);
            Assert.Equal("There aren't books registered", messageReturned);
        }







        [Fact]
        public async Task AddAsync_Book_ReturnCreated()
        {
            //Arrange
            var book = _fixture.Create<Book>();
            book.BookId = 0;
            var bookDto = _mapperReal.Map<BookDto>(book);

            _mapper.Setup(x => x.Map<Book>(bookDto))
                .Returns(book);

            _bookRepository.Setup(x => x.AddAsync(book));

            //Atc
            var response = await _sut.AddAsync(bookDto);

            //Assert
            var result = Assert.IsType<CreatedAtActionResult>(response);
            var bookReturn = Assert.IsType<BookDto>(result.Value);
            Assert.Equal((int)HttpStatusCode.Created, result.StatusCode);
            _bookRepository.Verify(x => x.AddAsync(book), Times.Once);
            _unitOfWork.Verify(x => x.CommitAsync(), Times.Once);
        }


        [Fact]
        public async Task UpdateAsync_WhenBookExists_ReturnNoContent()
        {
            //Arrange
            var book = _fixture.Create<Book>();
            var bookDto = _mapperReal.Map<BookDto>(book);


            _mapper.Setup(x => x.Map<Book>(bookDto))
                .Returns(book);


            _unitOfWork.Setup(x => x._bookRepository.Update(book));

            //Atc
            var response = await _sut.UpdateAsync(bookDto);

            //Assert
            var result = Assert.IsType<NoContentResult>(response);
            Assert.Equal((int)HttpStatusCode.NoContent, result.StatusCode);
            _bookRepository.Verify(x => x.Update(book), Times.Once);
            _unitOfWork.Verify(x => x.CommitAsync(), Times.Once);
        }


        [Fact]
        public async Task RemoveAsync_WhenBookExists_ReturnNoContent()
        {
            //Arrange
            var book = _fixture.Create<Book>();
            int id = book.BookId;

            _bookRepository.Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(book);

            _bookRepository.Setup(x => x.RemoveAsync(id));

            //Atc
            var response = await _sut.RemoveAsync(id);

            //Assert
            var result = Assert.IsType<NoContentResult>(response);
            Assert.Equal((int)HttpStatusCode.NoContent, result.StatusCode);
            _unitOfWork.Verify(x => x.CommitAsync(), Times.Once);
            _bookRepository.Verify(x => x.RemoveAsync(id), Times.Once);
        }

        [Fact]
        public async Task RemoveAsync_WhenBookNotExists_ReturnNotFound()
        {
            //Arrange
            int id = 1;
            _bookRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Atc
            var response = await _sut.RemoveAsync(id);

            //Assert
            var result = Assert.IsType<NotFoundObjectResult>(response);
            var messageReturned = Assert.IsType<string>(result.Value);
            Assert.Equal("Book not found", messageReturned);
            _bookRepository.Verify(x => x.RemoveAsync(id), Times.Never);
            _unitOfWork.Verify(x => x.CommitAsync(), Times.Never);
        }

    }
}
