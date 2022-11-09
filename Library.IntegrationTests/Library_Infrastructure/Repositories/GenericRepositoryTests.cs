using AutoFixture;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using Library.IntegrationTests.Common;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Library.IntegrationTests.Library_Infrastructure.Repositories
{
    public class GenericRepositoryTests
    {

        private readonly Fixture _fixture;
        public GenericRepositoryTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }


        [Fact(Skip = "should past bu throw:  System.ArgumentException : Can not instantiate proxy of class: Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry")]
        public async Task GetByIdAsync_WhenEntityExists_ReturnTheEntity()
        {
            //Arrange
            var entity = _fixture.Create<TestClass>();
            int entityId = entity.Id;
            var _contextMock = new Mock<DBLibraryContext>();
            var _dbSetMock = new Mock<DbSet<TestClass>>();





            _contextMock.Setup(x => x.Set<TestClass>())
            .Returns(_dbSetMock.Object)
            ;

            _contextMock.Setup(x => x.Entry(entity).State).Returns(EntityState.Detached);
            //_contextMock.Object.Entry(null).State = EntityState.Detached;

            _dbSetMock.Setup(x => x.FindAsync(entityId))
            .ReturnsAsync(entity)
            ;


            var _sut = new GenericRepository<TestClass>(_contextMock.Object);


            //Atc
            var responseEntity = await _sut.GetByIdAsync(entityId);

            //Assert
            Assert.Equal(entityId, entity.Id);
            _dbSetMock.Verify(x => x.FindAsync(entityId), Times.Once());

        }
    }
}
