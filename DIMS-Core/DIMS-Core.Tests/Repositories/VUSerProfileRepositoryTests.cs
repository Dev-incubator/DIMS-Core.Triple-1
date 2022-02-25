using DIMS_Core.Tests.Repositories.Fixtures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DIMS_Core.Tests.Repositories
{
    public class VUSerProfileRepositoryTests : IDisposable
    {
        private readonly VUSerProfileRepositoryFixture _fixture;

        public VUSerProfileRepositoryTests()
        {
            _fixture = new VUSerProfileRepositoryFixture();
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
