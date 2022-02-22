using DIMS_Core.Tests.Repositories.Fixtures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DIMS_Core.Tests.Repositories
{
    public class VUSerProgressRepositoryTests : IDisposable
    {
        private readonly VUserProgressRepositoryFixture _fixture;

        public VUSerProgressRepositoryTests()
        {
            _fixture = new VUserProgressRepositoryFixture();
        }

        public void Dispose()
        {
            _fixture.Dispose();
        }

        [Fact]
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
    }
}
