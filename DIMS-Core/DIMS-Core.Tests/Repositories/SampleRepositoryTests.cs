using System;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.Tests.Repositories.Fixtures;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.Repositories
{
    public class SampleRepositoryTests : IDisposable
    {
        private readonly SampleRepositoryFixture _fixture;

        public SampleRepositoryTests()
        {
            _fixture = new SampleRepositoryFixture();
        }

        public void Dispose()
        {
            _fixture.Dispose();
        }

        [Fact]
        // Note: GetAll will work always in our case. It can be thrown into EF Core.
        // But it is implementation details of EF Core so we mustn't test these cases.
        public async Task GetAll_OK()
        {
            // Act
            var result = await _fixture.Repository
                                       .GetAll()
                                       .ToArrayAsync();

            // Assert
            Assert.NotEmpty(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task GetById_OK()
        {
            // Act
            var result = await _fixture.Repository.GetById(_fixture.SampleId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(_fixture.SampleId, result.SampleId);
            Assert.Equal("Test Direction", result.Name);
            Assert.Equal("Test Description", result.Description);
        }

        [Fact]
        public Task GetById_EmptyId_Fail()
        {
            // Arrange
            const int id = 0;

            // Act, Assert
            return Assert.ThrowsAsync<ArgumentException>(() => _fixture.Repository.GetById(id));
        }

        [Fact]
        public Task GetById_NotExistDirection_Fail()
        {
            // Arrange
            const int id = int.MaxValue;

            // Act, Assert
            return Assert.ThrowsAsync<ArgumentNullException>(() => _fixture.Repository.GetById(id));
        }

        [Fact]
        public async Task Create_OK()
        {
            // Arrange
            var entity = new Sample
            {
                Name = "Create",
                Description = "Description"
            };

            // Act
            await _fixture.Repository.Create(entity);
            await _fixture.Context.SaveChangesAsync();

            // Assert
            Assert.NotNull(entity);
            Assert.NotEqual(default, entity.SampleId);
        }

        [Fact]
        public async Task Create_EmptyEntity_Fail()
        {
            // Arrange Act, Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _fixture.Repository.Create(null));
        }

        [Fact]
        public async Task Update_OK()
        {
            // Arrange
            var entity = new Sample
            {
                SampleId = _fixture.SampleId,
                Name = "Create",
                Description = "Description"
            };

            // Act
            _fixture.Repository.Update(entity);
            await _fixture.Context.SaveChangesAsync();

            // Assert
            Assert.NotNull(entity);
            Assert.NotEqual(default, entity.SampleId);
        }

        [Fact]
        public void Update_EmptyEntity_Fail()
        {
            // Arrange Act, Assert
            Assert.Throws<ArgumentNullException>(() => _fixture.Repository.Update(null));
        }

        [Fact]
        public async Task Delete_OK()
        {
            // Act
            await _fixture.Repository.Delete(_fixture.SampleId);
            await _fixture.Context.SaveChangesAsync();

            // Assert
            var deletedEntity = await _fixture.Context.Samples.FindAsync(_fixture.SampleId);
            Assert.Null(deletedEntity);
        }

        [Fact]
        public Task Delete_EmptyId_Fail()
        {
            // Arrange
            const int id = 0;

            // Act, Assert
            return Assert.ThrowsAsync<ArgumentException>(() => _fixture.Repository.Delete(id));
        }
    }
}