using DIMS_Core.Tests.Repositories.Fixtures;
using System;

namespace DIMS_Core.Tests.Repositories
{
    public class DirectionRepositoryTests : IDisposable
    {
        private readonly DirectionRepositoryFixture _fixture;

        public DirectionRepositoryTests()
        {
            _fixture = new DirectionRepositoryFixture();
        }

        public void Dispose()
        {
            _fixture.Dispose();
        }
    }
}
