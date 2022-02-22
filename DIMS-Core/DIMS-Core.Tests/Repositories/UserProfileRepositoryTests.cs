using DIMS_Core.Tests.Repositories.Fixtures;
using System;

namespace DIMS_Core.Tests.Repositories
{
    public class UserProfileRepositoryTests : IDisposable
    {
        private readonly UserProfileRepositoryFixture _fixture;

        public UserProfileRepositoryTests()
        {
            _fixture = new UserProfileRepositoryFixture();
        }

        public void Dispose()
        {
            _fixture.Dispose();
        }
    }
}
