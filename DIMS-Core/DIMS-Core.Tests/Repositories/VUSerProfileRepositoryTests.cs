using DIMS_Core.Tests.Repositories.Fixtures;
using System;

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
    }
}
