using AutoFixture;
using AutoMapper;
using Library.Core.Interfaces;
using Library.Core.Entities;
using Library.Core.Services;
using Library.Infrastructure.Mappings;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Library.IntegrationTests.Library_Core.Services
{
    public class AuthorServiceTests
    {
        private readonly AuthorService _sut;
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();
        private readonly Fixture _fixture;

        public AuthorServiceTests()
        {
            _sut = new AuthorService(_unitOfWork.Object);
            _fixture = new Fixture();
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }


        [Fact]
        public async Task GetByIdAsync_WhenAuthorExists_ReturnAuthor()
        {
            //Arrange
            var authorModel = _fixture.Create<Author>();
            int authorId = authorModel.AuthorId;

            _unitOfWork.Setup(x => x._authorReporitory.GetByIdAsync(authorId))
                .ReturnsAsync(authorModel);

            //Act
            var author = await _sut.GetAuthorAsync(authorId);

            //Assert
            Assert.Equal(authorId, author.AuthorId);
        }

        [Fact]
        public async Task GetByIdAsync_WhenUserNotExists_ReturnNull()
        {
            //Arrange
            int authorId = 1;
            _unitOfWork.Setup(x => x._authorReporitory.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Atc
            var author = await _sut.GetAuthorAsync(authorId);

            //Assert
            Assert.Null(author);
        }




        [Fact]
        public async Task GetAuthorsAsync_WhenAuthorsExists_ReturnAuthors()
        {
            //Arrange
            var authorListModel = _fixture.CreateMany<Author>(3).ToList();
            _unitOfWork.Setup(x => x._authorReporitory.GetAllAsync(default))
                .ReturnsAsync(authorListModel);

            //Act
            var authorList = await _sut.GetAuthorsAsync();

            //Assert
            Assert.NotNull(authorList);
            Assert.Equal(3, authorList.Count());
        }

        [Fact]
        public async Task AddAuthorAsync_Author_ReturnNothing()
        {
            //assert
            var authorModel = _fixture.Create<Author>();
            int authorId = authorModel.AuthorId;
            _unitOfWork.Setup(x => x._authorReporitory.AddAsync(authorModel));

            //Act
            await _sut.AddAuthorAsync(authorModel);

            //Assert
            _unitOfWork.Verify(x => x._authorReporitory.AddAsync(authorModel));
        }


        [Fact]
        public async Task UpdateAuthorAsync_Author_ReturnNothing()
        {
            //Arrange
            var author = _fixture.Create<Author>();
            int authorId = author.AuthorId;
            _unitOfWork.Setup(x => x._authorReporitory.Update(author));

            //Act
            await _sut.UpdateAuthorAsync(author);

            //Assert
            _unitOfWork.Verify(x => x._authorReporitory.Update(author));
        }
    }
}
